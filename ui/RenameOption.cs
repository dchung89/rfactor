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

namespace rfactor
{
    [ExcludeFromCodeCoverage]
    [ExportCodeRefactoringProvider("RfactorRename", LanguageNames.CSharp)]
    class RenameOption : ICodeRefactoringProvider
    {
        private readonly ICodeActionEditFactory editFactory;

        [ImportingConstructor]
        public RenameOption(ICodeActionEditFactory editFactory)
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

            var declaration = token.Parent.FirstAncestorOrSelf<VariableDeclaratorSyntax>();
            var variable = (VariableDeclaratorSyntax)declaration;
            if (declaration == null)
            {
                return null;
            }

            var semanticModel = (SemanticModel)document.GetSemanticModel();
            var symbol = semanticModel.GetDeclaredSymbol(variable);
            var workspace = workspaceDiscoveryService.GetWorkspace(document.GetText().Container);

            return new CodeRefactoring(
                new[] { new CodeAction0(workspace, renameService, document, symbol) },
                variable.Identifier.Span);
    }
}
