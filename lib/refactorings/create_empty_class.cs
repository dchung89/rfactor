using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace Rfactor.Lib.Refactorings
{
    /** 
     * Define a new class, with no locally defined members. If a superclass is specified 
     * as an argument, the new class becomes its direct subclass. 
     * 
     * Arguments: string newClassName, (optional) class superClass
     * 
     * Preconditions:
     *   1. forall class c in Program.classes
     *        class.name != newClassName
     *      (the name does not conflict with an already existing class)
     **/
    class create_empty_class
    {
        public static bool CheckPreconditions()
        {
            return false;
        }

        /** 
         * Returns an AST of the empty class
         **/
        public static SyntaxTree Create(string newClassName,string superClass = null)
        {
            string template = "class " + newClassName;
            if (superClass != null)
                template += " : " + superClass;
            template += @"
{
}";
            SyntaxTree tree = SyntaxTree.ParseCompilationUnit(template);
            return tree;
        }

    }

}
