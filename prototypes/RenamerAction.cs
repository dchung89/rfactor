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
using System.Diagnostics.CodeAnalysis;

namespace Rfactor.UI.Actions
{
    // Action for Casper's Renamer
    [Obsolete("Use RenameAction instead.")]
    [ExcludeFromCodeCoverage]
    public class RenamerAction : ICodeAction
    {
        private ICodeActionEditFactory editFactory;
        private IWorkspace workspace;
        private IRenameService renameService;
        private IDocument document;
        private ISymbol symbol;

        public RenamerAction(ICodeActionEditFactory editFactory, IWorkspace workspace,
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
