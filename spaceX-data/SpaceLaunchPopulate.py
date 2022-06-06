import pandas as pd
import pyodbc

#To create the tables in your database, first change connection string value in 'appsettings.json' to "SpaceLaunch": "Server=localhost;Database=SpaceLaunchDb;Trusted_Connection=True;"
# then run 'update-database' in visual studio package manager console

#Read in the data
capsules = pd.read_csv('./capsules-edited.csv')
launchpads = pd.read_csv('./launchpads.csv')
launches = pd.read_csv('./launches-edited.csv')
payloads = pd.read_csv('./payloads-edited.csv')
rockets = pd.read_csv('./rockets-edited.csv')

# Connect to SQL Server
# NB TO DETERMINE THE SERVER RUN THE FOLLOWING IN MSSQL: SELECT @@SERVERNAME
conn = pyodbc.connect('Driver={SQL Server};'
                      'Server=BRANDONS;'
                      'Database=SpaceLaunchDb;'
                      'Trusted_Connection=yes;')
cursor = conn.cursor()

# Insert rocket DataFrame to rocket Table
for row in rockets.itertuples():
    print(row)
    print('''
                INSERT INTO dbo.Rockets (RocketId, Name, Type, IsActive, Country, Company, HeightMt, HeightFt, DiameterMt, DiameterFt, MassKg, MassLb, Stages, Boosters, CostPerLaunch, Engines)
                VALUES ('{}','{}','{}','{}','{}','{}',{},{},{},{},{},{},{},{},{},'{}')
                '''.format(
                row.rocket_id,
                row.name,
                row.type,
                row.active,
                row.country,
                row.company,
                row.height_mt,
                row.height_ft,
                row.diameter_mt,
                row.diameter_ft,
                row.mass_kg,
                row.mass_lb,
                row.stages,
                row.boosters,
                row.cost_per_launch,
                row.engines))

    cursor.execute('''
                INSERT INTO dbo.Rockets (RocketId, Name, Type, IsActive, Country, Company, HeightMt, HeightFt, DiameterMt, DiameterFt, MassKg, MassLb, Stages, Boosters, CostPerLaunch, Engines)
                VALUES ('{}','{}','{}','{}','{}','{}',{},{},{},{},{},{},{},{},{},'{}')
                '''.format(
                row.rocket_id,
                row.name,
                row.type,
                row.active,
                row.country,
                row.company,
                row.height_mt,
                row.height_ft,
                row.diameter_mt,
                row.diameter_ft,
                row.mass_kg,
                row.mass_lb,
                row.stages,
                row.boosters,
                row.cost_per_launch,
                row.engines)
                )

for row in launchpads.itertuples():
    print(row)
    print('''
                INSERT INTO dbo.launchpads(LaunchpadId,Name ,FullName ,Status ,Locality ,Region ,TimeZone ,Latitude ,Longitude)
                VALUES ('{}','{}','{}','{}','{}','{}','{}',{},{})
                '''.format(
                    row.launchpad_id,
                    row.name,
                    row.full_name,
                    row.status,
                    row.locality,
                    row.region,
                    row.timezone,
                    row.latitude,
                    row.longitude)
                )

    cursor.execute('''
                INSERT INTO dbo.launchpads(LaunchpadId,Name ,FullName ,Status ,Locality ,Region ,TimeZone ,Latitude ,Longitude)
                VALUES ('{}','{}','{}','{}','{}','{}','{}',{},{})
                '''.format(
                    row.launchpad_id,
                    row.name,
                    row.full_name,
                    row.status,
                    row.locality,
                    row.region,
                    row.timezone,
                    row.latitude,
                    row.longitude)
                )

for row in launches.itertuples():
    print(row)
    print('''
                INSERT INTO dbo.launches(LaunchId,Name,Date,RocketId,LaunchpadId,Success,Failures)
                VALUES ('{}','{}','{}','{}','{}','{}','{}')
                '''.format(                  
                    row.launch_id,
                    row.name,
                    row.date,
                    row.rocket_id,
                    row.launchpad_id,
                    row.success,
                    row.failures,))

    cursor.execute('''
                INSERT INTO dbo.launches(LaunchId,Name,Date,RocketId,LaunchpadId,Success,Failures)
                VALUES ('{}','{}','{}','{}','{}','{}','{}')
                '''.format(                  
                    row.launch_id,
                    row.name,
                    row.date,
                    row.rocket_id,
                    row.launchpad_id,
                    row.success,
                    row.failures,)
                )

for row in capsules.itertuples():
    print(row)
    print('''
                INSERT INTO dbo.Capsules(CapsuleId,Serial,Status,ReuseCount,WaterLandings,LandLandings, LaunchId)
                VALUES ('{}','{}','{}',{},{},{}, '{}')
                '''.format(
                    row.capsule_id,
                    row.serial,
                    row.status,
                    row.reuse_count,
                    row.water_landings,
                    row.land_landings,
                    row.launch_id)
                )

    cursor.execute('''
                INSERT INTO dbo.Capsules(CapsuleId,Serial,Status,ReuseCount,WaterLandings,LandLandings, LaunchId)
                VALUES ('{}','{}','{}',{},{},{}, '{}')
                '''.format(
                    row.capsule_id,
                    row.serial,
                    row.status,
                    row.reuse_count,
                    row.water_landings,
                    row.land_landings,
                    row.launch_id)
                )

for row in payloads.itertuples():
    print(row)
    print('''
                INSERT INTO dbo.Payloads(PayloadId, Name, Type, Reused, Manufacturers, MassKg, MassLb, Orbit, ReferenceSystem, Regime, LaunchId)
                VALUES ('{}','{}','{}','{}','{}',{}, {},'{}', '{}', '{}', '{}')
                '''.format(
                    row.payload_id
                    , row.name
                    , row.type
                    , row.reused
                    , row.manufacturers
                    , row.mass_kg
                    , row.mass_lb
                    , row.orbit
                    , row.reference_system
                    , row.regime
                    , row.launch_id)
                )

    cursor.execute('''
                INSERT INTO dbo.Payloads(PayloadId, Name, Type, Reused, Manufacturers, MassKg, MassLb, Orbit, ReferenceSystem, Regime, LaunchId)
                VALUES ('{}','{}','{}','{}','{}',{}, {},'{}', '{}', '{}', '{}')
                '''.format(
                    row.payload_id
                    , row.name
                    , row.type
                    , row.reused
                    , row.manufacturers
                    , row.mass_kg
                    , row.mass_lb
                    , row.orbit
                    , row.reference_system
                    , row.regime
                    , row.launch_id)
                )

conn.commit()