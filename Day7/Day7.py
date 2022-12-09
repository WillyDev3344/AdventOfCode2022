class Root:
    def __init__(self, name) :
        self.nodes = []
        self.name = name
        self.data = {'size': 0}

    def addNode(self, node):
        self.nodes.append(node)

    def addData(self, fileName, fileSize):
        self.data[fileName] = fileSize
    
    def findNode(self, nodeName):
        for node in self.nodes:
            if node.name == nodeName:
                return node


class Node(Root):
    def __init__(self, name, parent) :
        self.nodes = []
        self.name = name
        self.data = {'size': 0}
        self.parent = parent

# def checkAllSmallNodes(node, maxSize):
#     nodeSize = node.data["size"]
#     if nodeSize <= maxSize and node.parent.data["size"] > maxSize:
#         global sizeSum
#         sizeSum += nodeSize
#     for nodes in node.nodes:
#         checkAllSmallNodes(nodes, maxSize)

dataTreeRoot = Root("/")
currentNode = dataTreeRoot

with open("Day7/input.txt") as f:
    for line in f:
        line = line.strip()
        if line.startswith("$ cd"):
            if line.startswith("$ cd .."):
                currentNode = currentNode.parent

            elif line.startswith("$ cd /"):
                currentNode = dataTreeRoot

            elif line.startswith("$ cd"):
                currentNode = currentNode.findNode(line[5:])

        elif line.startswith("dir"):
            newNode = Node(line[4:], currentNode)
            currentNode.addNode(newNode)

        elif line.startswith("$ ls"):
            pass

        else:
            file = line.split(" ")
            currentNode.addData(file[1], int(file[0]))
            newSize = currentNode.data["size"] + int(file[0])
            currentNode.data.update({"size": newSize})
            if not isinstance(currentNode, Root):
                currentNode.parent.data.update({"size": newSize})

# global sizeSum
# sizeSum = 0
# checkAllSmallNodes(dataTreeRoot, 100000)
# print(sizeSum)