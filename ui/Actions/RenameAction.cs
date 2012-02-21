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
    // Displays button in Quick Menu and
    // invokes class to call Rename Service.
    [ExcludeFromCodeCoverage]
    public class RenameAction : ICodeAction
    {
        private IWorkspace workspace;
        private IRenameService renameService;
        private IDocument document;
        private ISymbol symbol;

        public RenameAction(IWorkspace workspace, IRenameService renameService, IDocument document,
            ISymbol symbol)
        {
            this.workspace = workspace;
            this.renameService = renameService;
            this.document = document;
            this.symbol = symbol;
        }

        public string Description
        {
            get { return "Rfactor Rename"; }
        }

        public ImageSource Icon
        {
            get { return null; }
        }

        public ICodeActionEdit GetEdit(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Use a custom ICodeActionEdit instead.
            return new RenameEdit(workspace, renameService, document, symbol);
        }
    }
}