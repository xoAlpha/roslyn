' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports Microsoft.CodeAnalysis.Structure
Imports Microsoft.CodeAnalysis.VisualBasic.Structure
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Namespace Microsoft.CodeAnalysis.Editor.VisualBasic.UnitTests.Outlining
    Public Class ForBlockStructureProviderTests
        Inherits AbstractVisualBasicSyntaxNodeStructureProviderTests(Of ForBlockSyntax)

        Friend Overrides Function CreateProvider() As AbstractSyntaxStructureProvider
            Return New ForBlockStructureProvider()
        End Function

        <Fact, Trait(Traits.Feature, Traits.Features.Outlining)>
        Public Async Function TestForEachBlock1() As Task
            Const code = "
Class C
    Sub M()
        {|span:For v = 0 to 5 $$
        Next|}
    End Sub
End Class
"

            Await VerifyBlockSpansAsync(code,
                Region("span", "For v = 0 to 5 ...", autoCollapse:=False))
        End Function
    End Class
End Namespace
