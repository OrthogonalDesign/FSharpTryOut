module FSharpTryOut.Question

type QuestionType =
    | SingleChoice
    | MultipleChoice
type Option = string
type Category = string
type Author = string
type Choice = int
type Stem = string
type Analysis = string

type Answer =
    |SingleChoice of Choice
    |MultipleChoice of Choice list

type Question =
     {
         Author: Author option
         Stem: Stem
         Options: Option list
         RecommendedAnswer: Answer
         Analysis: Analysis
        
     }
   