module FSharpTryOut.Question

type QuestionType =
    | SingleChoice
    | MultipleChoice
type Option = string
type Category = string
type Author = string
type Choice = int

type Answer =
    |SingleChoice of Choice
    |MultipleChoice of Choice list
    
type Section =
    | Author of Author
    | Stem of string
    | Type of QuestionType
    | Options of Option list
    | Analysis of string
    | RecommendedAnswer of Answer
