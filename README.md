Simple Calculator
The Simple Calculator is a program that enables you to perform addition, subtraction, and multiplication operations on values stored in registers. It supports a simple syntax and allows for the use of registers as values with lazy evaluation.

Syntax
The syntax for using the calculator is as follows:

php
Copy code
register operation value
print register
quit
The allowed operations are add, subtract, and multiply.

Usage Examples
Example 1:
plaintext
Copy code
A add 2
A add 3
print A
B add 5
B subtract 2
print B
A add 1
print A
quit
Output:

plaintext
Copy code
5
3
6
Example 2:
plaintext
Copy code
a add 10
b add a
b add 1
print b
QUIT
Output:

plaintext
Copy code
11
Example 3:
plaintext
Copy code
result add revenue
result subtract costs
revenue add 200
costs add salaries
salaries add 20
salaries multiply 5
costs add 10
print result
QUIT
Output:

plaintext
Copy code
90
Note
The calculator supports the use of registers as values, which are lazily evaluated at the time of printing.

Feel free to try out different combinations of operations and registers to perform calculations.

Note: This program accepts input either from the standard input stream or from a file. When launching the program with a command-line argument specifying a file, the input will be read from that file, allowing for convenient usage.

To exit the program, use the quit command.
