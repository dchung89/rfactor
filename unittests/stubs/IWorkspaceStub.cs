using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Services.Editor;
using Roslyn.Services;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using System.Diagnostics.CodeAnalysis;

namespace Rfactor.UnitTests.Stubs
{
    [ExcludeFromCodeCoverage]
    class IWorkspaceStub : IWorkspace
    {
        public System.Threading.Tasks.Task<DocumentId> AddDocumentAsync(ProjectId project, IEnumerable<string> folders, string preferredDocumentName, IText initialText, SourceCodeKind sourceCodeKind = SourceCodeKind.Regular)
        {
            throw new NotImplementedException();
        }

        public void AddListener(IWorkspaceListener listener)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task AddMetadataReferenceAsync(ProjectId fromProject, MetadataReference toMetadata)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<ProjectId> AddProjectAsync(string projectName, string languageName)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task AddProjectReferenceAsync(ProjectId fromProject, ProjectId toProject)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> ApplyChangesAsync(ISolution oldSolution, ISolution newSolution, System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task CloseDocumentAsync(DocumentId document)
        {
            throw new NotImplementedException();
        }

        public ISolutionEdit CreateEdit(string description)
        {
            throw new NotImplementedException();
        }

        public ISolution CurrentInProgressSolution
        {
            get { throw new NotImplementedException(); }
        }

        public ISolution CurrentSolution
        {
            get { throw new NotImplementedException(); }
        }

        public bool EditInProgress
        {
            get { throw new NotImplementedException(); }
        }

        public DocumentId GetDocumentId(ITextContainer textContainer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IWorkspaceListener> Listeners
        {
            get { throw new NotImplementedException(); }
        }

        public System.Threading.Tasks.Task OpenDocumentAsync(DocumentId document)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task RemoveDocumentAsync(DocumentId document)
        {
            throw new NotImplementedException();
        }

        public void RemoveListener(IWorkspaceListener listener)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task RemoveMetadataReferenceAsync(ProjectId fromProject, MetadataReference toMetadata)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task RemoveProjectAsync(ProjectId projectId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task RemoveProjectReferenceAsync(ProjectId fromProject, ProjectId toProject)
        {
            throw new NotImplementedException();
        }

        public bool TryGetDocument(IText text, out IDocument document)
        {
            throw new NotImplementedException();
        }

        public bool TryGetDocumentFromInProgressSolution(IText text, out IDocument document)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateCompilationOptionsAsync(ProjectId project, Roslyn.Compilers.Common.ICompilationOptions options)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateDocumentAsync(DocumentId document, IText newText)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateParseOptionsAsync(DocumentId document, Roslyn.Compilers.Common.IParseOptions options)
        {
            throw new NotImplementedException();
        }

        public IWorkspaceVersion Version
        {
            get { throw new NotImplementedException(); }
        }
    }
}
