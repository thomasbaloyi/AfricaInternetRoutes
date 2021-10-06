import React from 'react';
import L from 'leaflet'; //import leaflet so as to utilise it for mapping datapoints onto the map of Africa.
import { Map, TileLayer, GeoJSON } from 'react-leaflet';
import './App.css';  // import the css
import 'leaflet/dist/leaflet.css'; //import leaflet css so as to utilise it for mapping datapoints onto the map of Africa.
import { json } from 'd3-fetch';
import { node } from 'prop-types';
//import exampleJson from './locationsJson/example.json'; //import the json file with the details of points that need to be mapped onto the map of Africa.


//initial geojson which will be used to map points onto the map.
const geoJsonInit = {
    "type": "FeatureCollection",
    "features": []
};

//function to create geoJson data
function populateAsnData(abbreviation,nationName,capitalLocation) {
    var jsonObj = {
        "type": "Feature",
        "id": abbreviation,  // assign the country's abbreviation as its ID.
        "properties": {
            "name": nationName,  //add country Name.
            "popupContent": nationName
        },
        "geometry": {
            "type": "Point", // indicate that this a point on the map.
            "coordinates": capitalLocation  // add in the country's latitude and longitude using the capital city.
        }
    };

    return jsonObj;  // return the json object to be pushed to the features array. 
}

/**
 * function used to create geojson for mapping asns onto the continent of Africa
 */
export default function geoJsonASNs() {
    /*
     * Firstly the application will access the ASN data from the ProcessedData folder.
     * In a loop it will check which country needs to be mapped onto the visualisation of Africa.
     * it will then create a json object for each nation following the format of example.json.
     * The coordinates of each nation will be retrieved from CountryNames.json
     */

    var asnLocations = geoJsonInit;  // add in the initial elements.
    var capitalLocations;  // used to contain the data obtained from CountryNames.json
    var asnData;  //used to contain the data obtained from ASNData.json.

    // include the fs module
    var fs = require('fs');

    // obtain data from CountryNames.json
    fs.readFile('./locationsJson/CountryNames.json', (err, data) => {
        capitalLocations = JSON.parse(data)  //parse through data and convert it from string to a JSON object.
    });

    //obtain data from ASNData.json
    fs.readFile('../ProcessedData/ASNData.json', (err, data) => {
        asnData = JSON.parse(data)  //parse through data and convert it from string to a JSON object.
    });

    //loop through asnData
    for (var asnfileData in asnData) {
        var countryName = asnfileData.country;
        //loop through capitalLocations to compare with countryName
        for (var locationData in capitalLocations) {
            /* 
             * compare countryName with all possible names for a country as listed in CountryNames.
             * if it matches then use populateAsnData function to create the data for our geojson.
             * push this data into the functions array in asnLocations.
             * if we do not find a match then we will assume the name used in the datafile is not a recognised one or we were unable to obtain the country's location.
             */
            if ((countryName === locationData.name) || (countryName === ("\u0022" + locationData.name + "\u0022"))) {
                asnLocations.features.push(populateAsnData(locationData.abbreviation, locationData.name, locationData.coordinates));
                break;
            }
            else if ((countryName === locationData.alternativeName1) || (countryName === ("\u0022" + locationData.alternativeName1 + "\u0022"))) {
                asnLocations.features.push(populateAsnData(locationData.abbreviation, locationData.name, locationData.coordinates));
                break;
            }
            else if ((countryName === locationData.alternativeName2) || (countryName === ("\u0022" + locationData.alternativeName2 + "\u0022"))) {
                asnLocations.features.push(populateAsnData(locationData.abbreviation, locationData.name, locationData.coordinates));
                break;
            }
            else if ((countryName === locationData.alternativeName3) || (countryName === ("\u0022" + locationData.alternativeName3 + "\u0022"))) {
                asnLocations.features.push(populateAsnData(locationData.abbreviation, locationData.name, locationData.coordinates));
                break;
            }
            else if ((countryName === locationData.alternativeName4) || (countryName === ("\u0022" + locationData.alternativeName4 + "\u0022"))) {
                asnLocations.features.push(populateAsnData(locationData.abbreviation, locationData.name, locationData.coordinates));
                break;
            }
            else if ((countryName === locationData.alternativeName5) || (countryName === ("\u0022" + locationData.alternativeName5 + "\u0022"))) {
                asnLocations.features.push(populateAsnData(locationData.abbreviation, locationData.name, locationData.coordinates));
                break;
            }
            else if ((countryName === locationData.alternativeName6) || (countryName === ("\u0022" + locationData.alternativeName6 + "\u0022"))) {
                asnLocations.features.push(populateAsnData(locationData.abbreviation, locationData.name, locationData.coordinates));
                break;
            }
        }
    }

    return asnLocations;  //return the geojson object.
}



/*delete L.Icon.Default.prototype._getIconUrl;

//apply blue pins as markers for the mapping.
L.Icon.Default.mergeOptions({
   iconRetinaUrl: require('leaflet/dist/images/marker-icon-2x.png'),
   iconUrl: require('leaflet/dist/images/marker-icon.png'),
   shadowUrl: require('leaflet/dist/images/marker-shadow.png')
});

const initialAfricaZoom = 2; //set the initial zoom in so that the user sees the whole continent of Africa only.
const coordinatesAfricaCenter = [7.943625, 24.329730]; //set center point so that continent appears centrally in the display.

function App() {
    return (
        <div className="App">
            <Map center={defaultCenter} zoom={defaultZoom}>
                <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" attribution="&copy; <a href=&quot;https://www.openstreetmap.org/copyright&quot;>OpenStreetMap</a> contributors" />
                <GeoJSON data={exampleJson} />
            </Map>
        </div>
    );
}

export default App;*/