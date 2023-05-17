
# Variables


# Targets
clean:
	@echo "Cleaning up..."
	@sudo find src -name "obj" -type d -exec rm -rf {} \;
	@sudo find src -name "bin" -type d -exec rm -rf {} \;
	@echo "Cleaned! (removed obj/ and bin/ directories)"

build:
	@echo "Building..."
	@dotnet build src/
	@echo "Built!"

run:
	@echo "Running..."
	@dotnet run --project src/Api/
	@echo "Ran!"

tests: 
	@echo "Running tests..."
	@dotnet test src/Tests/
	@echo "Tests ran!"

net: clean run