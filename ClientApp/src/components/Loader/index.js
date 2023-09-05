import React from "react";
import "./Loader.css";

const Loader = () => {
    return (
        // <div className="lds-ring  row justify-content-center">
        //     <div></div>
        //     <div></div>
        //     <div></div>
        //     <div></div>
        // </div>
        <img className="row justify-content-center"
            src="https://i.pinimg.com/originals/0d/98/ce/0d98ce657d01311ac1824ead2570046b.gif"
        />
    );
};

export default Loader;