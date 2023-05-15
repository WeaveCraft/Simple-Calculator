# Simple Calculator

## The calculator can add, subtract and multiply values in a set of registers
---
- `register` `operation` `value`
- print `register`
- quit
---

## **Quick start**
### in terminal, `dotnet build` -> run program `ctrl + f5`

## Allowed operations are add, subtract and multiply:
- A add 2
- A add 3
- print A
- B add 5
- B subtract 2
- print B
- A add 1
- print A
- quit
## The output will be:
- 5
- 3
- 6

## The calculator can also support using registers as values with lazy evaluation (evaluated at print)
- result add revenue
- result subtract costs
- revenue add 200
- costs add salaries
- salaries add 20
- salaries multiply 5
- costs add 10
- print result
- QUIT
## The output will be:
- 90
