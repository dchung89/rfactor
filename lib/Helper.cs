using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace rfactor.lib.preconditions
{


    class Helper
    {
        // 4.3.1 Boolean Primitive Functions
        public static bool compilesP();
        public static bool convertibleToFunctionP();
        public static bool qualifiesAsComponentP();
        public static bool noSideEffectsP();
        public static bool satisfiesClassInvariantP();
        public static bool semanticallyEquivalentP();
        public static bool subtypeP();
        public static bool unrefdOnInstancesP();

        // 4.3.2 Other Primitive Functions
        public static void firstConditionImpliedByInvariant();
        
        // 4.3.3 Non-primitive Boolean Functions
        public static void inheritedMemberFunctionNamedP();
        public static void matchingAttributesP();
        public static void matchingAttributesP();
        public static void matchingSignatureP();
        public static void memberFunctionNamedP();
        public static void redundantIfAddedP();
        public static void varNameCollisionP();

        // 4.3.4 Other Non-primitive functions
        public static void allFunctions();
        public static void allVariables();
        public static void callsTo();
        public static void classesInternallyReferencing();
        public static void classesPubliclyReferencing();
        public static void classesReferencing();
        public static void classesReferencing();
        public static void collidingFunction();
        public static void containingClass();
        public static void containingFunction();
        public static void directSubclassesOf();
        public static void directSuperClassOf();
        public static void expressionsAssignedTo();
        public static void expressionsAssignedToArgument();
        public static void functionsCalledBy();
        public static void functionsThatOverride();
        public static void inheritedMembers();
        public static void inheritedMemberFunctions();
        public static void inheritedMemberVariables();
        public static void locallyDefinedMembersOf();
        public static void localVariablesIn();
        public static void memberFunctionNamed();
        public static void memberVariablesNamed();
        public static void membersOf();
        public static void referencesTo();
        public static void referencesTo();
        public static void referencesTo();
        public static void scopeOf();
        public static void setOfComponentVariables();
        public static void subclassesOf();
        public static void superclassesOf();
        public static void variablesAssigned();
        public static void variablesAssigned();
        public static void variablesAssigned();
        public static void variablesReferencedBy();

    }
}
