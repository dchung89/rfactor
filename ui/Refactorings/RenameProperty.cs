using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;
using System.Diagnostics.CodeAnalysis;
using Rfactor.UI.Actions;

namespace Rfactor.UI.Refactorings
{
    // Rename property refactoring provider
    // that enables the Quick Menu option.
    [ExcludeFromCodeCoverage]
    [ExportCodeRefactoringProvider("Rename", LanguageNames.CSharp)]
    class RenameProperty : ICodeRefactoringProvider
    {
        private readonly ICodeActionEditFactory editFactory;

        [ImportingConstructor]
        public RenameProperty(ICodeActionEditFactory editFactory)
        {
            this.editFactory = editFactory;
        }

        [Import]
        private IRenameService renameService = null;

        [Import]
        private IWorkspaceDiscoveryService workspaceDiscoveryService = null;

        public CodeRefactoring GetRefactoring(IDocument document, TextSpan textSpan, CancellationToken cancellationToken)
        {
            var syntaxTree = document.GetSyntaxTree(cancellationToken);
            var token = syntaxTree.Root.FindToken(textSpan.Start);
            if (token.Parent == null)
            {
                return null;
            }

            var declaration = token.Parent.FirstAncestorOrSelf<PropertyDeclarationSyntax>();
            var variable = (PropertyDeclarationSyntax)declaration;
            if (declaration == null)
            {
                return null;
            }

            var semanticModel = (SemanticModel)document.GetSemanticModel();
            var symbol = semanticModel.GetDeclaredSymbol(variable);
            var workspace = workspaceDiscoveryService.GetWorkspace(document.GetText().Container);

            return new CodeRefactoring(
                new[] { new RenameAction(workspace, renameService, document, symbol) },
                variable.Identifier.Span);
        }
    }
}
