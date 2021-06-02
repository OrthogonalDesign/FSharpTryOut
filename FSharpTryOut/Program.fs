// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open FParsec
open FSharpTryOut.Question
open FSharpTryOut.Question_Parsers

let test p str  =
    match run p str with
    | Success(result, _, _) ->  printfn "Success: %A" result
    | Failure(errorMsg, _, _) -> printfn "Falure: %s" errorMsg
    
let testFile p path =
     match runParserOnFile  p () path System.Text.Encoding.UTF8 with
    | Success(result, _, _) ->  printfn "Success: %A" result
    | Failure(errorMsg, _, _) -> printfn "Falure: %s" errorMsg

[<EntryPoint>]
let main argv =
    test pQuestionType "一、单选题\n"
    test pQuestionType "一、多选题\n"
    test pCategory "（一）党建理论知识\n"
    test pStem "1．	党的十九大报告提出的三大攻坚战是指(    )
"
    //test pCategory "二、 类别"
    //testFile parser "/Users/haowang/Documents/test.txt"
    0 // return an integer exit code
    