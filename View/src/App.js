//Modified from :https://github.com/muratkemaldar/using-react-hooks-with-d3.git

import './App.css';
import React,{ useState,Component } from "react";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import GeoAfrica from "./GeoAfrica";
import data from "./GeoAfrica.custom.geo.json";


function App() {

  const [property, setProperty] = useState("pop_est");
  return(

    <TransformWrapper
        initialScale={1.25}
        initialPositionX={50}
        initialPositionY={40}
      >
        {({ zoomIn, zoomOut, resetTransform, ...rest }) => (
  
    <React.Fragment>
    <h2>Africa Internet Routes Map  </h2>
    <div >
              <button onClick={() => zoomIn()}>zoom in</button>
              <button onClick={() => zoomOut()}>zoom out</button>
              <button onClick={() => resetTransform()}>reset </button>


            </div>

            <TransformComponent >
  <div id="africa">
  <GeoAfrica data={data} property={property}/>
  </div>

  </TransformComponent>

    
    <h2>Select criteria to filter by</h2>
    <select
      value={property}
      onChange= {event=> setProperty(event.target.value)}
    >

    <option value="pop_est">Population</option>
    <option value="ASNs">ASNs</option>
    <option value="IXPs">IXPs</option>

    
    </select>
    </React.Fragment>
    )}
    </TransformWrapper>

    /*
        var xy = projection([-26.1714537,27.8999389])
        svg.append("circle").attr({
            cx: xy[0],
            cy: xy[1],
            r: 5,
            fill: "blue"})
*/

  );
}

export default App;

