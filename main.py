def create_dict(dict):
    lines = open("result.csv",'r').readlines()

    for line in lines:
        Item = line.strip().split(';')[0]
        Igredients = line.strip().split(';')[1:]

        dict[Item] = Igredients


def search(dict,item,item_count = 1):
    create_dict(dict)

    
    try:
        ingredients = dict[item]

        for i in range(len(ingredients)):
            item_number = int(ingredients[i].split(" ")[0])
            ingredients[i] = str(item_number*item_count) + " " + " ".join(ingredients[i].split(" ")[1:])
            
        
        newIngredientList = []
        for ingredient in ingredients:
            nb_ingredient = int(" ".join(ingredient.split(" ")[0]))
            ingredientName = " ".join(ingredient.split(" ")[1:])
            if isInDict(dict,ingredientName) == True:
                subIngredientList = search(dict,ingredientName,nb_ingredient)

                for subIngredient in subIngredientList:
                    newIngredientList.append(subIngredient)
            else:
                newIngredientList.append(str(nb_ingredient) + " " + ingredientName)
        return newIngredientList
   
    except:
        return None
    
    

def isInDict(dict,item):
    try:
        return dict[item] != None
    except:
        return False 



def main():
    dict = {}
    create_dict(dict)
    item ="Elixir of Armor"
    igredients = search(dict,item,1)

    if(igredients == None):
        print("Item not found")
    else:
        print("For {} you need:".format(item))
        print("\t",end='')
        print("\n\t".join(igredients))



main()