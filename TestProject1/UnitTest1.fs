module TestProject1

open NUnit.Framework
open FSharpTryOut.Question_Parsers

[<SetUp>]
let Setup () =
    ()

[<Test>]
let pword_test () =
    Assert.AreEqual("hello", (pword "hello " ))