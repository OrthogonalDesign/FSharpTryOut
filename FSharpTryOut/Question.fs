module FSharpTryOut.Question

type QuestionType =
    | SingleChoice
    | MultipleChoice
type Option = string
type Category = string
type Answer = int

type Section =
    | Stem of string
    | Type of QuestionType
    | Options of Option list
    | Analysis of string
    | RecommendedAnswer of Answer
    | RecommendedAnswers of Answer list
    

    