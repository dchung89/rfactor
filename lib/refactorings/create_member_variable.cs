using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace Rfactor.Lib.Refactorings
{
    /** 
     * Add an unreferenced locally dened member variable to a class
     * 
     * Arguments:  variable V, class C
     * 
     * Preconditions:
     *   1. ~varNameCollisionP(V.name, C)
     *      (the name of the new variable does not clash with an existing member or global variable)
     **/
    class create_member_variable
    {
        public static bool CheckPreconditions()
        {
            return false;
        }

        /** 
         * Returns an AST of the member variable
         **/
        public static SyntaxTree Create(string varName, string className)
        {
            string template = "var " + varName;
           
            SyntaxTree tree = SyntaxTree.ParseCompilationUnit(template);
            return tree;
        }
    }
}
