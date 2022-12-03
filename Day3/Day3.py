priority = ["0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", 'm', "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", 
                 "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ]
sum = 0
trioSum = 0
i = 1
trio = []

with open("Day3/input.txt") as f:
    for line in f:
        # Part 1
        line = line.strip()
        for char in set(line[:len(line)//2]).intersection(set(line[len(line)//2:])):
            sum += priority.index(char)
        
        # Part 2
        trio.append(line)
        if i%3 == 0:
            elf1 = set(trio[0])
            elf2 = set(trio[1])
            elf3 = set(trio[2])

            intersect = elf1.intersection(elf2)
            for char in elf3.intersection(intersect):
                trioSum += priority.index(char)
            trio.clear()
        i += 1 

# Part 1
print(sum)
# Part 2
print(trioSum) 