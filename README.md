# Data Importer
.Net solution with the following projects :
- DataImporter : a wpf MVVM app that imports csv files of data grid with depth data and then creates meta data out of the imported file, then also calculates the volume of between two layers (Top layer and base layer)

![image](https://user-images.githubusercontent.com/25548321/187957427-ee4c374b-5a98-4b63-9bb7-b634bbed8faf.png)

- DataImporter.Services : The services layer that are being used by multiple projects in this solution
- DataImporter.Services.NUnit : NUnits for the service
- DataImporter.Web : asp core project with one example controller, which hardcoded to read from one file on desk.


# CSV file example 
![image](https://user-images.githubusercontent.com/25548321/187957663-f967e9e8-11c0-4dbb-a1f3-0610ff92e54e.png)


# Exported JSON file with meta data example 
![image](https://user-images.githubusercontent.com/25548321/187957845-72500566-a76d-497b-9e35-4f505776adeb.png)



# Resources Location 
- CSV import example files can be found in \Documents\
- JSON out files can be also found in \Documents\
