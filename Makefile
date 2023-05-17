
# Variables


# Targets
clean:
	@echo "Cleaning up..."
	@find src/ -depth -name "obj" -type d -exec rm -rf {} \;
	@find src/ -depth -name "bin" -type d -exec rm -rf {} \;
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