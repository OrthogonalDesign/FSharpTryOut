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
    //test pQuestionType "一、单选题\n"
    //test pQuestionType "一、多选题\n"
    //test pCategory "（一）党建理论知识\n"
    //test pStem "1．	党的十九大报告提出的三大攻坚战是指(    )\n"
    //test pOption "A．精准脱贫、防范金融风险、污染防治\n"
    //test pOptions "A．10月17日\nB．3月12日\nC．3月15日\nD．10月10日\n"
    //test pChoice "A"
    //test pChoice "C"
    //test pChoices "C"
    //test pChoices "CD"
   // test pAnswer "ABD"
    //test pRecommendedAnswer "答案：C\n"
    //test pRecommendedAnswer "答案：AC\n"
    //test pAnalysis "解析：根据《劳动合同法》第八十五条规定，用人单位有下列情形之一的，由劳动行政部门责令限期支付劳动报酬、加班费或者经济补偿；劳动报酬低于当地最低工资标准的，应当支付其差额部分；逾期不支付的，责令用人单位按应付金额百分之五十以上百分之一百以下的标准向劳动者加付赔偿金：（一）未按照劳动合同的约定或者国家规定及时足额支付劳动者劳动报酬的；（二）低于当地最低工资标准支付劳动者工资的；（三）安排加班不支付加班费的；（四）解除或者终止劳动合同，未依照本法规定向劳动者支付经济补偿的。\n"
    //test pCategory "二、 类别"
    //test pQuestion1 "1．	党的十九大报告提出的三大攻坚战是指(    )\nA．精准脱贫、防范金融风险、污染防治\n"
    //testFile pQuestion "/Users/haowang/Documents/question.txt"
    testFile pDoc "/Users/haowang/Documents/test.txt"
    0 // return an integer exit code
    