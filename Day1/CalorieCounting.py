calSum = 0
biggestSum = 0
sumList = []

with open("caloriesInput.txt") as f:
    for line in f:
        if line == "\n":
            if calSum > biggestSum : biggestSum = calSum
            sumList.append(calSum)
            calSum = 0
        else:
            ammount = line.replace("\n", "")
            calSum += int(ammount)
# Part 1
print(biggestSum)

#Part 2
sortedList = sorted(sumList, reverse=True)
print(sum(sortedList[0:3]))

