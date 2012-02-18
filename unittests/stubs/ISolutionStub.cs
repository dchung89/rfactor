using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace rfactor.unittests.stubs
{
    class ISolutionStub : ISolution
    {
        public ISolution AddDocument(IDocument document)
        {
            throw new NotImplementedException();
        }

        public ISolution AddDocument(DocumentId documentId)
        {
            throw new NotImplementedException();
        }

        public ISolution AddDocument(DocumentId documentId, string displayName, Func<System.Threading.CancellationToken, Roslyn.Compilers.IText> loadText)
        {
            throw new NotImplementedException();
        }

        public ISolution AddDocument(DocumentId documentId, string displayName, Roslyn.Compilers.IText text)
        {
            throw new NotImplementedException();
        }

        public ISolution AddMetadataReference(ProjectId projectId, Roslyn.Compilers.MetadataReference metadataReference)
        {
            throw new NotImplementedException();
        }

        public ISolution AddMetadataReferences(ProjectId projectId, IEnumerable<Roslyn.Compilers.MetadataReference> metadataReferences)
        {
            throw new NotImplementedException();
        }

        public ISolution AddProject(IProject project)
        {
            throw new NotImplementedException();
        }

        public ISolution AddProject(ProjectId projectId, string language, string displayName, Func<string> getAssemblyName, Func<IEnumerable<DocumentInfo>> getDocuments, Func<IEnumerable<ProjectId>> getProjectReferences, Func<IEnumerable<Roslyn.Compilers.MetadataReference>> getMetadataReferences, Func<Roslyn.Compilers.Common.ICompilationOptions> getCompilationOptions, Func<Roslyn.Compilers.Common.IParseOptions> getParseOptions, Roslyn.Compilers.AssemblyResolver assemblyResolver = null, bool isSubmission = false, ProjectId previousSubmissionProjectId = null)
        {
            throw new NotImplementedException();
        }

        public ISolution AddProject(ProjectId projectId, string language, string assemblyName, string displayName)
        {
            throw new NotImplementedException();
        }

        public ISolution AddProjectReference(ProjectId projectId, ProjectId referencedProject)
        {
            throw new NotImplementedException();
        }

        public ISolution AddProjectReferences(ProjectId projectId, IEnumerable<ProjectId> referencedProjects)
        {
            throw new NotImplementedException();
        }

        public ISolution Clone()
        {
            throw new NotImplementedException();
        }

        public ISolution CloseDocument(DocumentId documentId, Func<System.Threading.CancellationToken, Roslyn.Compilers.IText> loadText)
        {
            throw new NotImplementedException();
        }

        public bool ContainsDocument(DocumentId documentId)
        {
            throw new NotImplementedException();
        }

        public bool ContainsProject(ProjectId projectId)
        {
            throw new NotImplementedException();
        }

        public ISolutionDifferences GetDifferences(ISolution oldSolution)
        {
            throw new NotImplementedException();
        }

        public IDocument GetDocument(Roslyn.Compilers.Common.CommonSyntaxTree syntaxTree)
        {
            throw new NotImplementedException();
        }

        public IDocument GetDocument(DocumentId documentId)
        {
            throw new NotImplementedException();
        }

        public IProject GetProject(ProjectId projectId)
        {
            throw new NotImplementedException();
        }

        public IProject GetProjectByAssemblyName(string assemblyName)
        {
            throw new NotImplementedException();
        }

        public IProject GetProjectByDisplayName(string displayName)
        {
            throw new NotImplementedException();
        }

        public Roslyn.Compilers.MetadataReference GetReferencedProjectMetadata(ProjectId fromProject, ProjectId toProject, System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool HasProjects
        {
            get { throw new NotImplementedException(); }
        }

        public SolutionId Id
        {
            get { throw new NotImplementedException(); }
        }

        public Roslyn.Compilers.IMetadataFileProvider MetadataFileProvider
        {
            get { throw new NotImplementedException(); }
        }

        public ISolution OpenDocument(DocumentId documentId, Roslyn.Compilers.IText newText)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectId> ProjectIds
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IProject> Projects
        {
            get { throw new NotImplementedException(); }
        }

        public ISolution RemoveAllDocuments(ProjectId projectId)
        {
            throw new NotImplementedException();
        }

        public ISolution RemoveAllMetadataReferences(ProjectId projectId)
        {
            throw new NotImplementedException();
        }

        public ISolution RemoveAllProjectReferences(ProjectId projectId)
        {
            throw new NotImplementedException();
        }

        public ISolution RemoveDocument(DocumentId documentId)
        {
            throw new NotImplementedException();
        }

        public ISolution RemoveMetadataReference(ProjectId projectId, Roslyn.Compilers.MetadataReference metadataReference)
        {
            throw new NotImplementedException();
        }

        public ISolution RemoveProject(ProjectId projectId)
        {
            throw new NotImplementedException();
        }

        public ISolution RemoveProjectReference(ProjectId projectId, ProjectId referencedProject)
        {
            throw new NotImplementedException();
        }

        public ISolution UpdateCompilationOptions(ProjectId projectId, Roslyn.Compilers.Common.ICompilationOptions options)
        {
            throw new NotImplementedException();
        }

        public ISolution UpdateDocument(IDocument document)
        {
            throw new NotImplementedException();
        }

        public ISolution UpdateDocument(DocumentId documentId, Roslyn.Compilers.IText newText, Roslyn.Compilers.TextChangeRange[] changes)
        {
            throw new NotImplementedException();
        }

        public ISolution UpdateDocument(DocumentId documentId, Roslyn.Compilers.IText text)
        {
            throw new NotImplementedException();
        }

        public ISolution UpdateFolders(DocumentId documentId, IEnumerable<string> folderNames)
        {
            throw new NotImplementedException();
        }

        public ISolution UpdateMetadataReference(ProjectId projectId, Roslyn.Compilers.MetadataReference oldMetadata, Roslyn.Compilers.MetadataReference newMetadata)
        {
            throw new NotImplementedException();
        }

        public ISolution UpdateParseOptions(ProjectId projectId, Roslyn.Compilers.Common.IParseOptions options)
        {
            throw new NotImplementedException();
        }

        public ISolution UpdateSourceCodeKind(DocumentId documentId, Roslyn.Compilers.SourceCodeKind kind)
        {
            throw new NotImplementedException();
        }
    }
}
