## Run Command 

dotnet restore && dotnet run

## Test Script 
curl -s http://files.olo.com/pizzas.json | jq -c -r '. | to_entries[] | .value.toppings | sort |  @csv' | tr -d '"' | sort | uniq -c | sort -r | head -20
