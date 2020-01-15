module Tests

open Xunit
open Rith.Lib

[<Fact>]
let ``parse input with spaces`` () =
    Assert.Equal(Expr.Parse(" 1 +  3*    7   "), (Plu (Int 1u, Mul (Int 3u, Int 7u))))

[<Fact>]
let ``associativity`` () =
    Assert.Equal(Expr.Parse("50/5*2"), (Mul (Div (Int 50u, Int 5u), Int 2u)))
    Assert.Equal(Expr.Parse("50-5+2"), (Plu (Min (Int 50u, Int 5u), Int 2u)))

[<Fact>]
let ``precedence`` () =
    Assert.Equal(Expr.Parse("50-5*2"), (Min (Int 50u, (Mul (Int 5u, Int 2u)))))