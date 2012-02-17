using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Roslyn.Services.Editor;
using Roslyn.Services;
using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;
using System.Windows.Media;
using System.Threading;

namespace rfactor
{   
    // Action for RenameServiceActionEdit
    public class CodeAction0 : ICodeAction
    {
        private IWorkspace workspace;
        private IRenameService renameService;
        private IDocument document;
        private ISymbol symbol;

        public CodeAction0(IWorkspace workspace, IRenameService renameService, IDocument document,
            ISymbol symbol)
        {
            this.workspace = workspace;
            this.renameService = renameService;
            this.document = document;
            this.symbol = symbol;
        }

        public string Description
        {
            get { return "Rfactor Rename Service"; }
        }

        public ImageSource Icon
        {
            get { return null; }
        }

        public ICodeActionEdit GetEdit(CancellationToken cancellationToken = default(CancellationToken))
        {

            // Use a custom ICodeActionEdit instead.
            return new RenameServiceActionEdit(workspace, renameService, document, symbol);
        }
    }
    // Action for Casper's Renamer
    public class CodeAction1 : ICodeAction
    {
        private ICodeActionEditFactory editFactory;
        private IWorkspace workspace;
        private IRenameService renameService;
        private IDocument document;
        private ISymbol symbol;

        public CodeAction1(ICodeActionEditFactory editFactory, IWorkspace workspace,
            IRenameService renameService, IDocument document, ISymbol symbol)
        {
            this.editFactory = editFactory;
            this.workspace = workspace;
            this.renameService = renameService;
            this.document = document;
            this.symbol = symbol;
        }

        public string Description
        {
            get { return "Rfactor Renamer"; }
        }

        public ImageSource Icon
        {
            get { return null; }
        }

        public ICodeActionEdit GetEdit(CancellationToken cancellationToken = default(CancellationToken))
        {
            var tree = (SyntaxTree)document.GetSyntaxTree(cancellationToken);
            Renamer renamer = new Renamer(symbol.Name.ToString(), symbol.Name.ToUpper());
            var newRoot = renamer.Visit(tree.Root);
            return editFactory.CreateTreeTransformEdit(
                document.Project.Solution, tree, newRoot);
        }
    }
}