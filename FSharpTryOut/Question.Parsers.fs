module FSharpTryOut.Question_Parsers
open FParsec
open Question

let pword s = pstring s .>> spaces
let chinese_number = [|'一'; '二'; '三'; '四';'五';'六';'七';'八';'九';'十';|]
let chinese_pause = '、'
let chinese_dot='．'
let chinese_round_bracket_open = '（'
let chinese_round_bracket_close = '）'
let option_letter =[|'A'; 'B'; 'C'; 'D'; 'E'; 'F'|]

let pChineseNumber = anyOf chinese_number
let pOptionLetter = anyOf option_letter
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
        choice[pSingleQuestion; pMultipleQuestion] .>> newline
        
let pAuthor : Parser<Author, unit> =
    skipString "命题单位：" >>. restOfLine true  
    
let pStem : Parser<Stem, unit> =
    pint8 >>. skipChar chinese_dot >>. spaces
    >>. restOfLine true 

   
let pOption : Parser<Option, unit> =
    pOptionLetter >>. skipChar chinese_dot >>. many1CharsTill anyChar newline
    

let pOptions: Parser<Option list, unit> = many pOption
   
let pChoiceToIndex = function
    |'A' -> 0
    |'B' -> 1
    |'C' -> 2
    |'D' -> 3
    |'E' -> 4
    |'F' -> 5

    
let pChoice : Parser<Choice,unit> =
    pOptionLetter |>> pChoiceToIndex
let pChoices :Parser<Choice list, unit> =
     many1 pChoice
   

let pAnswer  =
    pChoices
    |>> function x ->
        match x with
            | s when s.Length = 1 -> SingleChoice(s.[0])
            | m when m.Length > 1 -> MultipleChoice(m)
    
let pRecommendedAnswer : Parser<Answer, unit> =
    skipString "答案：" >>. pAnswer .>> newline

let pAnalysis : Parser<Analysis, unit>  =
    skipString "解析：" >>. restOfLine true

let pQuestion1 : Parser<Question, unit> =
  pipe5 pAuthor pStem pOptions pRecommendedAnswer pAnalysis (
      fun author stem options answer  analysis ->
          { Author=option.Some(author); Stem=stem; Options=options; RecommendedAnswer=answer; Analysis=analysis })
 
let pQuestion2 : Parser<Question, unit> =
  pipe4 pStem pOptions pRecommendedAnswer pAnalysis (
      fun stem options answer  analysis ->
          {Author=option.None; Stem=stem; Options=options; RecommendedAnswer=answer; Analysis=analysis })

let pQuestion = choice[pQuestion1; pQuestion2]
    
let pCategoryPart  =
    pCategory .>>. many1 pQuestion
    
let pQuestionTypePart =
    pQuestionType .>>. many1 pCategoryPart
    
let pDoc = many1 pQuestionTypePart .>> eof

    
 