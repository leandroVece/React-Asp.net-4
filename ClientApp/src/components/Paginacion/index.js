import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

const Paginacion = ({ totalPages, param, url }) => {

    const [boton, setBoton] = useState([]);
    const [pageNumber, setpageNumber] = useState(param)
    const [pase, setPase] = useState(false)
    const nav = useNavigate();
    const paramUrl = useParams()

    function cargarArray(inicial, final) {
        let array = []
        for (let index = inicial; index <= final; index++) {
            array.push(index)
        }
        return array
    }

    useEffect(() => {
        let arrayCargado = []
        if (pageNumber < 6 && (totalPages < 6)) {
            arrayCargado = arrayCargado.concat(cargarArray(1, totalPages))
            setBoton(arrayCargado)
            return
        }
        if (pageNumber + 4 >= totalPages) {
            arrayCargado.push(1)
            arrayCargado.push("...")
            arrayCargado = arrayCargado.concat(cargarArray(totalPages - 4, totalPages))
            setBoton(arrayCargado)
            return
        }
        if (totalPages > 6 && pageNumber > 1) {
            arrayCargado.push(1)
            arrayCargado.push("...")
            arrayCargado = arrayCargado.concat(cargarArray(pageNumber, pageNumber + 3))
            arrayCargado.push("...")
            arrayCargado.push(totalPages)
            setBoton(arrayCargado)
            return
        }
        else {
            arrayCargado = arrayCargado.concat(cargarArray(pageNumber, pageNumber + 3))
            arrayCargado.push("...")
            arrayCargado.push(totalPages)
            setBoton(arrayCargado)
        }
        //solo para que se haga una vez, porque ya habria un nueva recarga al cambiar la url
    }, [paramUrl, totalPages, pase])

    const handelClickMore = () => {
        if (pageNumber < totalPages)
            setpageNumber(pageNumber + 1)
    }
    const handelClickless = () => {
        if (pageNumber > 1)
            setpageNumber(pageNumber - 1)
    }

    const handelClick = (page) => {
        setpageNumber(page)
    }

    useEffect(() => {
        if (pageNumber > 1 || pase) {
            setPase(true)
            nav(`/${url}/${pageNumber}`)
        }
    }, [pageNumber])

    useEffect(() => {
        setpageNumber(1)
        setPase(false)
    }, [url])


    return (
        <>
            <nav aria-label="Page navigation example">
                <ul className="pagination justify-content-center">
                    <li className="page-item"><a className="page-link" onClick={handelClickless} >Previous</a></li>
                    {boton.map((b, index) => {
                        if (b == "...")
                            return (<li key={index} onClick={handelClick} className="page-link">{b}</li>)
                        if (b == pageNumber) {
                            return (
                                <li key={index} className="page-item active" aria-current="page">
                                    <a className="page-link" >{b}</a>
                                </li>)
                        }
                        else
                            return (<li key={"li" + index} onClick={() => handelClick(b)} className="page-item"><a className="page-link" >{b}</a></li>)
                    })}
                    <li className="page-item"><a onClick={handelClickMore} className="page-link" >Next</a></li>
                </ul>
            </nav>
        </>
    );
}

export default Paginacion;