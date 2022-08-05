
def alchemy():
    lines = open("old_source_alchemy.csv",'r').readlines()

    for i in range(len(lines)):
        lines[i] = lines[i].strip()

    while True:
        try:
            lines.remove("")
            print("Success")
        except:
            print("Failed")
            break

    dict = {}
    newLines = []
    currentline = ""
    for i in range(len(lines)):
        if lines[i][0].isdigit() == True:
            currentline += (lines[i] + ";")
        else:
            newLines.append(currentline[:-1])
            currentline = lines[i] + ";"

    newLines.append(currentline[:-1])
    newLines.append("Blood 1;1 BLOOD Wolf, Flamingo, Rhino, Cheetah")
    newLines.append("Blood 2;1 BLOOD Deer, Sheep, Goat, Cow, Pig, Ox, Waragon")
    newLines.append("Blood 3;1 BLOOD Weasel, Fox, Racoon")
    newLines.append("Blood 4;1 BLOOD Bear, Troll, Ogre")
    newLines.append("Blood 5;1 BLOOD Worm, Lizard, Bat, Kuku")

    open("alchemy.csv",'w').writelines(newLine + '\n' for newLine in newLines)

def cooking():
    lines = open("old_source_cooking.csv",'r').readlines()

    for i in range(len(lines)):
        lines[i] = lines[i].strip()

    while True:
        try:
            lines.remove("")
            print("Success")
        except:
            print("Failed")
            break

    dict = {}
    newLines = []
    currentline = ""
    for i in range(len(lines)):
        if lines[i][0].isdigit() == True:
            currentline += (lines[i] + ";")
        else:
            newLines.append(currentline[:-1])
            currentline = lines[i] + ";"

    newLines.append(currentline[:-1])
    newLines.append("Starch Potato;1 Corn, Barley, Sweet Potato, Wheat")
    newLines.append("Vegetable Tomato;1 Paprika, Pumpkin, Cabbage, Olive")
    newLines.append("Fruit Strawberry;1 Grape, Apple, Cherry, Pear, Banana, Pineapple")
    newLines.append("Bird meat Kuku;1 Chicken, Flamingo")

    open("cooking.csv",'w').writelines(newLine + '\n' for newLine in newLines)


alchemy()
cooking()

def sort_alchemy_and_cooking():
    lines = open('alchemy.csv','r').readlines()
    lines.sort()

    open('alchemy.csv','w').writelines(lines)

    lines2 = open('cooking.csv','r').readlines()

    lines2.sort()
    open('cooking.csv','w').writelines(lines2)

sort_alchemy_and_cooking()