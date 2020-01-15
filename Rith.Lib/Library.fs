namespace Rith

type ParsingException (msg: string) =
    inherit System.Exception(msg)

module Lib =
    open FParsec

    type Expr = Int of uint32
              | Plu of Expr * Expr
              | Min of Expr * Expr
              | Mul of Expr * Expr
              | Div of Expr * Expr
        with

        static member Parse (str: string) =
            let opp = new OperatorPrecedenceParser<Expr,unit,unit>()
            let term = spaces >>. puint32 .>> spaces |>> Int
            opp.TermParser <- term

            let operators = [ 
                ("+", 1, Plu)
                ("-", 1, Min)
                ("*", 2, Mul)
                ("/", 2, Div)
            ]

            let addOp (char, prec, ctor) =
                let f a b = ctor (a, b)
                opp.AddOperator(InfixOperator(char, spaces, prec, Associativity.Left, f))

            operators |> List.iter addOp

            let pExpr = opp.ExpressionParser .>> eof

            match run pExpr str with
            | Success (expr, _, _) -> expr
            | Failure (err, _, _) -> raise <| ParsingException(err)


        member this.Evaluate () =
            let rec eval = function
              Int a -> decimal a
            | Plu (a, b) -> eval a + eval b
            | Min (a, b) -> eval a - eval b
            | Mul (a, b) -> eval a * eval b
            | Div (a, b) -> eval a / eval b

            eval this
