module FSharpTryOut.Question_Parsers
open System
open FParsec
open Question

let pword s = pstring s .>> spaces
let chinese_number = [|'一'; '二'; '三'; '四';'五';'六';'七';'八';'九';'十';|]
let chinese_pause = '、'
let chinese_round_bracket_open = '（'
let chinese_round_bracket_close = '）'

let pChineseNumber = anyOf chinese_number
let pSkipMany1ChineseNumber :Parser<unit, unit> = skipMany1 pChineseNumber

let parens p = between
                        (skipChar chinese_round_bracket_open)
                        (skipChar chinese_round_bracket_close) p
                        
let pCategory : Parser<Category,unit> =
        parens pSkipMany1ChineseNumber
        >>. many1CharsTill anyChar newline |>> string

let pSingleQuestion = stringReturn "单选题" QuestionType.SingleChoice
let pMultipleQuestion = stringReturn "多选题" QuestionType.MultipleChoice
let pQuestionType : Parser<QuestionType,unit> =
    pSkipMany1ChineseNumber  >>. skipChar chinese_pause >>.
        choice[pSingleQuestion; pMultipleQuestion]