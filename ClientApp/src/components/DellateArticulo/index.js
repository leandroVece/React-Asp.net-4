import React, { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { GlobalContext } from '../../ApiContext';
import { Container } from 'reactstrap';
import Loader from '../Loader';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import './style.css'

const imgLocal = require.context("../../../public/upload", true)

const Details = () => {

    const {
        setUrl,
        loading,
        db
    } = React.useContext(GlobalContext)
    const param = useParams();

    setUrl(`/articuloCategoria/${param.id}`)
    //RECIBO EL ID CON EL CUAL HAGO LA CONSULTA.
    const handelStart = (e) => {
        console.log(e.target.value);
    }

    const handelError = (e) => {
        e.target.src = "./img/imgPd-flex justify-content-md-endiente.jpg";
        e.target.onerror = null;
    }

    const style = {
        img: {
            widgh: "420px",
            height: "260px"
        }
    }
    //console.log(db);

    return (
        <Container>

            <div className='mt-5'>
                {loading && <Loader />}
                {db && (
                    <div >
                        <div className='d-md-flex justify-content-evenly'>
                            {/* carrucel */}
                            <div id="carouselExampleControls" className="carousel slide col-4" data-bs-ride="carousel">
                                <div className="carousel-inner">
                                    {db.articulo?.archivos?.length > 0 ? (
                                        db.articulo.archivos.map((arc, index) => {
                                            if (index === 0)
                                                return <div className="carousel-item active" key={index} >
                                                    <img onError={handelError}
                                                        className="d-block w-100" alt="..."
                                                        src={imgLocal(arc.name ? `./${arc.name}` : "./imgPendiente.jpg")}
                                                        style={style.img}
                                                    />
                                                </div>
                                            else
                                                return <div className="carousel-item" key={index} >
                                                    <img onError={handelError}
                                                        className="d-block" alt="..."
                                                        src={imgLocal(arc.name ? `./${arc.name}` : "./imgPendiente.jpg")}
                                                        style={style.img}
                                                    />
                                                </div>
                                        }
                                        )) : (
                                        <div className="carousel-item active">
                                            <img src="./img/imgPendiente.jpg" className="d-block w-100" alt="..." />
                                        </div>
                                    )}
                                </div>
                                <button className="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                                    <span className="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span className="visually-hidden">Previous</span>
                                </button>
                                <button className="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                                    <span className="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span className="visually-hidden">Next</span>
                                </button>
                            </div>

                            <div>
                                <h2>{db.articulo?.name}</h2>

                                {/* Datos relacionados */}
                                <h3>Costo: ${db.articulo?.price}</h3>
                                <h5>Stock: {db.articulo?.stock}</h5>
                                <button type='button' className='btn btn-outline-dark'>Comprar</button>
                                <button type='button' className='btn btn-outline-dark'>Agregar</button>
                            </div>

                        </div>
                        <div className='m-4'>
                            <h5 className="h4 pb-2 mb-4 text-danger border-bottom border-danger">Detalles por parte del proveerdor</h5>
                            {db.articulo?.descripcion ?
                                (<p>{db.articulo?.descripcion}</p>
                                ) : (
                                    <p>Sin detalles del producto</p>
                                )}
                        </div>
                        <div className='w-75 mx-auto my-5'>
                            <figure className="text-d-flex justify-content-md-end">
                                <blockquote className="blockquote">
                                    <h3>A well-known quote, contained in a blockquote element.</h3>
                                </blockquote>
                                <figcaption className="blockquote-footer">
                                    Someone famous in <cite title="Source Title">Source Title</cite>
                                </figcaption>
                            </figure>
                            <div className='text-secondary py-3 '>
                                <span>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Porro nobis quibusdam aperiam dolore aliquid ut sequi repellat fugiat deserunt! At culpa officia autem saepe necessitatibus, sed eius cumque asperiores blanditiis.</span>
                                <span>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Porro nobis quibusdam aperiam dolore aliquid ut sequi repellat fugiat deserunt! At culpa officia autem saepe necessitatibus, sed eius cumque asperiores blanditiis.</span>
                                <span>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Porro nobis quibusdam aperiam dolore aliquid ut sequi repellat fugiat deserunt! At culpa officia autem saepe necessitatibus, sed eius cumque asperiores blanditiis.</span>
                                <br />
                                <span>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Porro nobis quibusdam aperiam dolore aliquid ut sequi repellat fugiat deserunt! At culpa officia autem saepe necessitatibus, sed eius cumque asperiores blanditiis.</span>
                                <span>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Porro nobis quibusdam aperiam dolore aliquid ut sequi repellat fugiat deserunt! At culpa officia autem saepe necessitatibus, sed eius cumque asperiores blanditiis.</span>
                                <span>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Porro nobis quibusdam aperiam dolore aliquid ut sequi repellat fugiat deserunt! At culpa officia autem saepe necessitatibus, sed eius cumque asperiores blanditiis.</span>
                                <br />
                                <span>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Porro nobis quibusdam aperiam dolore aliquid ut sequi repellat fugiat deserunt! At culpa officia autem saepe necessitatibus, sed eius cumque asperiores blanditiis.</span>
                                <span>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Porro nobis quibusdam aperiam dolore aliquid ut sequi repellat fugiat deserunt! At culpa officia autem saepe necessitatibus, sed eius cumque asperiores blanditiis.</span>
                                <span>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Porro nobis quibusdam aperiam dolore aliquid ut sequi repellat fugiat deserunt! At culpa officia autem saepe necessitatibus, sed eius cumque asperiores blanditiis.</span>
                            </div>
                        </div>

                        {/* Estrellas de calificacion */}

                        <div className="d-md-flex justify-content-evenly  border-top border-danger">
                            <div className='flex-lg-fill w-100 m-4 p-2'>
                                <h3>¿Calificar el producto?</h3>
                                <form className='w-75 mx-auto'>

                                    <p className="clasificacion">
                                        <input id="radio1" type="radio" onClick={(e) => handelStart(e)} name="estrellas" value="5" />
                                        <label htmlFor="radio1">★</label>

                                        <input id="radio2" type="radio" onClick={(e) => handelStart(e)} name="estrellas" value="4" />
                                        <label htmlFor="radio2">★</label>

                                        <input id="radio3" type="radio" onClick={(e) => handelStart(e)} name="estrellas" value="3" />
                                        <label htmlFor="radio3">★</label>

                                        < input id="radio4" type="radio" onClick={(e) => handelStart(e)} name="estrellas" value="2" />
                                        <label htmlFor="radio4">★</label>

                                        <input id="radio5" type="radio" onClick={(e) => handelStart(e)} name="estrellas" value="1" />
                                        <label htmlFor="radio5">★</label>
                                    </p>
                                </form>
                                <h3 className="lead">¿Por que dejar un comentario?</h3>
                                <p>Dejar la calificacion permite que nuestros usuarios sepa sobre el valor de los productos de nuestros proveedores y asi mismo nos permite mejorar en las a travez de sus experiencia </p>
                            </div>

                            <div className=' flex-lg-fill w-100 p-2  '>
                                <table className="table table-sm table-striped">
                                    <thead>
                                        <tr>
                                            <th scope="col">Puntuacion: <samp className="bi bi-star text-primary" />3.0</th>
                                            <th scope="col">Cantidad</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">
                                                <samp className="bi bi-star text-primary" />
                                            </th>
                                            <td className="text-primary">3 Usuarios <i className="bi bi-person-circle "></i></td>

                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <samp className="bi bi-star text-primary" />
                                                <samp className="bi bi-star text-primary" />
                                            </th>
                                            <td className="text-primary">3 Usuarios <i className="bi bi-person-circle "></i></td>

                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <samp className="bi bi-star text-primary" />
                                                <samp className="bi bi-star text-primary" />
                                                <samp className="bi bi-star text-primary" />
                                            </th>
                                            <td className="text-primary">3 Usuarios <i className="bi bi-person-circle "></i></td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <samp className="bi bi-star text-primary" />
                                                <samp className="bi bi-star text-primary" />
                                                <samp className="bi bi-star text-primary" />
                                                <samp className="bi bi-star text-primary" />
                                            </th>
                                            <td className="text-primary">3 Usuarios <i className="bi bi-person-circle "></i></td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <samp className="bi bi-star text-primary" />
                                                <samp className="bi bi-star text-primary" />
                                                <samp className="bi bi-star text-primary" />
                                                <samp className="bi bi-star text-primary" />
                                                <samp className="bi bi-star text-primary" />
                                            </th>
                                            <td className="text-primary">3 Usuarios <i className="bi bi-person-circle "></i> </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </div>

                        {/* comentarios */}


                        <div className="form-floating  border-3 border-bottom  border-primary mb-5 ">
                            <textarea className="form-control bg-light border-0 p-3" placeholder="Leave a comment here" id="floatingTextarea2" ></textarea>
                            <label htmlFor="floatingTextarea2 " className='text-primary'>Comments</label>
                        </div>

                        <div className=''>
                            <div className="card w-75 my-4">
                                <div className="card-header bg-dark text-white">
                                    <span className="bi bi-person-circle"></span> Nombre de usuario
                                </div>
                                <div className="card-body " >
                                    <blockquote className="blockquote mb-0">
                                        <p>Opinion del usuario</p>
                                        <footer className="blockquote-footer">descriocion del comentario </footer>
                                    </blockquote>
                                </div>
                            </div>
                            <div className="card w-75 my-4 d-flex justify-content-md-end ">
                                <div className="card-header bg-dark text-white ">
                                    <span className="bi bi-person-circle"></span> Nombre de usuario
                                </div>
                                <div className="card-body">
                                    <blockquote className="blockquote mb-0">
                                        <p>Opinion del usuario</p>
                                        <footer className="blockquote-footer"> descriocion del comentario </footer>
                                    </blockquote>
                                </div>
                            </div>
                            <div className="card w-75 my-4 d-flex justify-content-md-end">
                                <div className="card-header bg-dark text-white">
                                    <span className="bi bi-person-circle"></span> Nombre de usuario
                                </div>
                                <div className="card-body">
                                    <blockquote className="blockquote mb-0">
                                        <p>Opinion del usuario</p>
                                        <footer className="blockquote-footer">descriocion del comentario </footer>
                                    </blockquote>
                                </div>
                            </div>
                        </div>
                    </div>
                )
                }
                {!db && (<h1>Error de conexion</h1>)}

            </div >
        </Container>
    );
};

export default Details;