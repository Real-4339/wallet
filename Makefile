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
	@dotnet test tests/Tests/
	@echo "Tests ran!"

help:
	@echo "Usage: make [target]"
	@echo "Targets:"
	@echo "  clean - Clean up the project"
	@echo "  build - Build the project"
	@echo "  run - Run the project"
	@echo "  tests - Run the tests"
	@echo "  help - Show this help message"