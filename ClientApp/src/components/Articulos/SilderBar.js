import React, { useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';

const SilderBar = ({ filtro, setFiltro, db }) => {

    const [form, setForm] = useState(filtro);
    const style = {
        sidebar: {
            width: "280px",
            height: `calc(100vh)`,
            position: "sticky",
            left: 0,
        },
    };

    const handleChange = (e) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value
        });
    };

    const handelSubmit = (e) => {
        e.preventDefault();
        var array = []
        for (const clave in form) {
            if (form[clave]) {
                array.push([clave, form[clave]])
            }
        }
        var obj = Object.fromEntries(array)
        setFiltro(obj);
    }

    return (
        <>
            <button className="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#collapseWidthExample" aria-expanded="false" aria-controls="collapseWidthExample">
                <span className="bi bi-menu-up" />
            </button>
            <section className="bd-highlight me-4 collapse-horizontal" id="collapseWidthExample">
                <div className="d-flex flex-column flex-shrink-0 p-3 text-white bg-dark" style={style.sidebar}>
                    <form onSubmit={handelSubmit}>
                        <p className="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-white text-decoration-none">
                            <svg className="bi me-2" width="40" height="32"><a href="#" /></svg>
                            <span className="fs-4">Sidebar </span>
                        </p>
                        <hr />
                        <div className="nav nav-pills flex-column mb-auto">
                            <div className="nav nav-pills flex-column mx-4 ">
                                <div className="list-unstyled ps-0">
                                    <button className="btn btn-toggle  text-white rounded collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseCategoria" aria-expanded="false" aria-controls="collapseCategoria">
                                        Categoria
                                    </button>
                                    <div className="collapse" id="collapseCategoria">
                                        <div className="align-items-center mt-2">
                                            <select className="form-select"
                                                onChange={handleChange} name="categoriaName"
                                            >
                                                <option defaultValue={""} value={""} placeholder="Select">Ninguno</option>
                                                {db.length > 0 ?
                                                    (db.map((data) =>
                                                        <option
                                                            value={data.name}
                                                            key={data.id}
                                                        >{data.name}</option>
                                                        // <div className="form-check" key={data.id}>
                                                        //     <input className="form-check-input" type="radio"  id="flexRadioDefault1"
                                                        //         value={data.name} onChange={handleChange} />
                                                        //     <label className="form-check-label" htmlFor="flexRadioDefault1">
                                                        //         {data.name}
                                                        //     </label>
                                                        // </div>
                                                    )) : (
                                                        <option>Error en Db</option >
                                                    )}
                                            </select>
                                            {/* <div className="form-check">
                                                <input className="form-check-input" type="radio" name="categoriaName" id="flexRadioDefault1"
                                                    value={"Informatica"} onChange={handleChange} />
                                                <label className="form-check-label" htmlFor="flexRadioDefault1">
                                                    Informatica
                                                </label>
                                            </div> 
                                            <div className="form-check mt-2">
                                                <input className="form-check-input" type="radio" name="categoriaName" id="flexRadioDefault1"
                                                    value={form.categoriaName} onChange={handleChange} />
                                                <label className="form-check-label" htmlFor="flexRadioDefault1">
                                                    Hombre
                                                </label>
                                            </div>
                                            <div className="form-check mt-2">
                                                <input className="form-check-input" type="radio" name="categoriaName" id="flexRadioDefault1"
                                                    value={form.categoriaName} onChange={handleChange} />
                                                <label className="form-check-label" htmlFor="flexRadioDefault1">
                                                    Celulares
                                                </label>
                                            </div>*/}

                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div className="list-unstyled ps-0">
                                    <button className="btn btn-toggle text-white rounded collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePrecio" aria-expanded="false" aria-controls="collapsePrecio">
                                        Precio
                                    </button>
                                    <div className="collapse mt-2" id="collapsePrecio">
                                        <div className="my-3 row">
                                            <label htmlFor="inputNumber" className="col-sm-2 col-form-label">Min</label>
                                            <div className="col-sm-9">
                                                <input type="number" className="form-control" placeholder="Min Price" name="priceMin" id="inputNumber"
                                                    value={form.priceMin} onChange={handleChange} />
                                            </div>
                                        </div>
                                        <div className="mb-3 row">
                                            <label htmlFor="inputNumberMax" className="col-sm-2 col-form-label">Max</label>
                                            <div className="col-sm-9">
                                                <input type="number" className="form-control" placeholder="Max Price" name="priceMax" id="inputNumberMax"
                                                    value={form.priceMax} onChange={handleChange} />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div className="list-unstyled ps-0">
                                    <button className="btn btn-toggle  text-white rounded collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseArticulo" aria-expanded="false" aria-controls="collapseArticulo">
                                        Articulo
                                    </button>
                                    <div className="collapse mt-2" id="collapseArticulo">
                                        <div className="">
                                            <input className="form-control me-2" type="text" placeholder="Name" name="articuloName" aria-label="Search"
                                                value={form.articuloName} onChange={handleChange} />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div className="dropdown">
                            <div className="d-grid gap-2  mx-auto mt-4">
                                <button className="btn btn-outline-success me-2" type="submit">Search</button>
                            </div>
                        </div>
                    </form>
                </div>
            </section >
        </>
    )
}

export default SilderBar;