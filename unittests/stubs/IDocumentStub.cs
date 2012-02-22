using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace Rfactor.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    class IDocumentStub : IDocument
    {
        public string DisplayName
        {
            get { throw new NotImplementedException(); }
        }

        public IList<string> Folders
        {
            get { throw new NotImplementedException(); }
        }

        public Roslyn.Compilers.Common.ISemanticModel GetSemanticModel(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Roslyn.Compilers.Common.CommonSyntaxTree GetSyntaxTree(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Roslyn.Compilers.IText GetText(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public DocumentId Id
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsEquivalentTo(IDocument document, System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool IsOpened
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsTopLevelEquivalentTo(IDocument document, System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ILanguageServiceProvider LanguageServices
        {
            get { throw new NotImplementedException(); }
        }

        public IProject Project
        {
            get { throw new NotImplementedException(); }
        }

        public Roslyn.Compilers.SourceCodeKind SourceCodeKind
        {
            get { throw new NotImplementedException(); }
        }

        public bool TryGetSemanticModel(out Roslyn.Compilers.Common.ISemanticModel semanticModel)
        {
            throw new NotImplementedException();
        }

        public bool TryGetSyntaxTree(out Roslyn.Compilers.Common.CommonSyntaxTree tree)
        {
            throw new NotImplementedException();
        }

        public bool TryGetText(out Roslyn.Compilers.IText text)
        {
            throw new NotImplementedException();
        }
    }
}
