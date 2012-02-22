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

namespace Rfactor
{
    [ExcludeFromCodeCoverage]
    // Provider for the RenameServiceActionEdit
    [ExportCodeRefactoringProvider("RfactorRename", LanguageNames.CSharp)]
    class CodeRefactoringProvider0 : ICodeRefactoringProvider
    {
        private readonly ICodeActionEditFactory editFactory;

        [ImportingConstructor]
        public CodeRefactoringProvider0(ICodeActionEditFactory editFactory)
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
                new[] { new RenameAction(workspace, renameService, document, symbol) },
                variable.Identifier.Span);
        }
    }
    [ExcludeFromCodeCoverage]
    // Provider that uses RenameServiceActionEdit, does use edit factory
    [ExportCodeRefactoringProvider("RfactorRename", LanguageNames.CSharp)]
    class CodeRefactoringProvider1 : ICodeRefactoringProvider
    {
        private readonly ICodeActionEditFactory editFactory;

        [ImportingConstructor]
        public CodeRefactoringProvider1(ICodeActionEditFactory editFactory)
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
                new[] { new RenamerAction(editFactory, workspace, renameService, document, symbol) },
                variable.Identifier.Span);
        }
    }
    [ExcludeFromCodeCoverage]
    // Method Renaming
    [ExportCodeRefactoringProvider("RfactorRename", LanguageNames.CSharp)]
    class CodeRefactoringProvider2 : ICodeRefactoringProvider
    {
        private readonly ICodeActionEditFactory editFactory;

        [ImportingConstructor]
        public CodeRefactoringProvider2(ICodeActionEditFactory editFactory)
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

            var declaration = token.Parent.FirstAncestorOrSelf<MethodDeclarationSyntax>();
            var variable = (MethodDeclarationSyntax)declaration;
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
    [ExcludeFromCodeCoverage]
    // Class Renaming
    [ExportCodeRefactoringProvider("RfactorRename", LanguageNames.CSharp)]
    class CodeRefactoringProvider3 : ICodeRefactoringProvider
    {
        private readonly ICodeActionEditFactory editFactory;

        [ImportingConstructor]
        public CodeRefactoringProvider3(ICodeActionEditFactory editFactory)
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

            var declaration = token.Parent.FirstAncestorOrSelf<ClassDeclarationSyntax>();
            var variable = (ClassDeclarationSyntax)declaration;
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
    [ExcludeFromCodeCoverage]
    // Parameter Renaming
    [ExportCodeRefactoringProvider("RfactorRename", LanguageNames.CSharp)]
    class CodeRefactoringProvider4 : ICodeRefactoringProvider
    {
        private readonly ICodeActionEditFactory editFactory;

        [ImportingConstructor]
        public CodeRefactoringProvider4(ICodeActionEditFactory editFactory)
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

            var declaration = token.Parent.FirstAncestorOrSelf<ParameterSyntax>();
            var variable = (ParameterSyntax)declaration;
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
    [ExcludeFromCodeCoverage]
    // Directive Renaming
    [ExportCodeRefactoringProvider("RfactorRename", LanguageNames.CSharp)]
    class CodeRefactoringProvider5 : ICodeRefactoringProvider
    {
        private readonly ICodeActionEditFactory editFactory;

        [ImportingConstructor]
        public CodeRefactoringProvider5(ICodeActionEditFactory editFactory)
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

            var declaration = token.Parent.FirstAncestorOrSelf<DefineDirectiveSyntax>();
            var variable = (DefineDirectiveSyntax)declaration;
            if (declaration == null)
            {
                return null;
            }

            var semanticModel = (SemanticModel)document.GetSemanticModel();
            var symbol = semanticModel.GetDeclaredSymbol(variable);
            var workspace = workspaceDiscoveryService.GetWorkspace(document.GetText().Container);

            return new CodeRefactoring(
                new[] { new RenameAction(workspace, renameService, document, symbol) },
                variable.DirectiveNameToken.Span);
        }
    }
}
