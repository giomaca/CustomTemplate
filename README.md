Install the Template:
  Open a terminal and navigate to the root directory of your template (the directory containing .template.config).
  Run the following command to install the template:
  dotnet new install .
  This command installs the template from the current directory, named "cleanddd" (it can be changed from .template.config).

Use the Template:
  After installation, you can create a new project based on your template by running:
  
  dotnet new cleanddd -n NewProjectName
