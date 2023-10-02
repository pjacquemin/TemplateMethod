# Template method design pattern

Here is a demo project to show how to implement the template method design pattern.
The main idea of this design pattern is to have an abstract class with a skeleton of an algorithm which is splitted into several operations which can be extended.

The design pattern itself is in Generator.cs file and classes that implement the template algorithm are CsvGenerator, CsvGenerator2022 and PDFGenerator.
These classes are finally called in program.cs