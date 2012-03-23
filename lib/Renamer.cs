using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rfactor.Lib.Preconditions;
using Roslyn.Compilers;
using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace Rfactor.Lib
{
    class Renamer
    {
        IDocument doc;
        TextSpan text;
        String newName;
        CommonSyntaxNodeOrToken selected;
        IEnumerable<IPrecondition> preconditions;

        public Renamer(IDocument doc, TextSpan text, String newName)
        {
            this.doc = doc;
            this.text = text;
            this.newName = newName;
            this.selected = doc.GetSyntaxTree().Root.DescendentNodesAndTokensAndSelf(text).First();
            this.preconditions = new List<IPrecondition>();
        }

        public IEnumerable<IPrecondition> GetPreconditions()
        {
            List<IPrecondition> list = new List<IPrecondition>();
            list.Add(new LocalNameConflict(newName, selected, (SyntaxTree)doc.GetSyntaxTree()));
            return list;
        }
        
    }
}
