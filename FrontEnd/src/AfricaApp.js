import React from 'react';
import L from 'leaflet'; //import leaflet so as to utilise it for mapping datapoints onto the map of Africa.
import { Map, TileLayer, GeoJSON } from 'react-leaflet';
import './App.css';  // import the css
import 'leaflet/dist/leaflet.css'; //import leaflet css so as to utilise it for mapping datapoints onto the map of Africa.
//import exampleJson from './locationsJson/example.json'; //import the json file with the details of points that need to be mapped onto the map of Africa.


//Create the map and tiles

/* 
 * set default center of the map
 * The lat and lng of Bikoro, DRC  was found to be the best center position with 
 * preset zoom of 3 which is able to visualise the whole of Africa.
 * Testing this was done using a combination of codesandbox.io and Google Maps.
 */
const africamap = L.map("airmap").setView([-1.014845, 18.024018], 3);
// use openstreet to visualise the map.
const attribution =
    '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors';

const tileUrl = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
const tiles = L.tileLayer(tileUrl, { attribution });
tiles.addTo(mymap);

/**
 * function used to map asns onto the continent of Africa
 */
export default function mapASNs() {
    /*
     * Firstly the application will access the ASN data from the ProcessedData folder.
     * In a loop it will check which country needs to be added
     */
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