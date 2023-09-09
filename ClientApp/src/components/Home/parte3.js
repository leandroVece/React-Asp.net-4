import React from "react";

const Parte3 = function () {

    return (
        <>
            <section className="section" data-section="section1">
                <div className="container fs-5 ">
                    <div className="section-heading mt-4 border-bottom border-danger ">
                        <h2 className="d-flex justify-content-center">Presentacion del proyecto</h2>
                        <p className="fs-5">
                            En esta ultima parte vamos a dar algunos retoques finales. Para esto vamos a fusionar ambos trabajos, vamos hacer una paginacion, solicitudes limitadas y creacion de un perfil.
                            <a className="" href="https://github.com/leandroVece/React-Asp.net-3" > Click para la tercera parte</a>
                        </p>
                        <p className="fs-5">
                            Este proyecto web se inició con fines puramente educativos. Para poder tomar esta primera parte es necesario tener conocimientos previos sobre React Js, Asp.net, Entity Framework, Fluen Api(deseable) y Linq(deseable).
                        </p>
                        <p className="fs-5">
                            Aunque el nivel no es muy grande para entender que es lo que vamos a hacer en este trabajo, siempre puedes ver sobre C# y asp.net en tutoriales en los foros o Youtube. Así mismo, tengo unas series de pequeños tutoriales separados en partes de:
                        </p>
                        <ul>
                            <li>
                                <a href="https://github.com/leandroVece/React">React </a>
                            </li>
                            <li>
                                <a href="https://github.com/leandroVece/Linq">Linq </a>
                            </li>
                            <li>
                                <a href="https://github.com/leandroVece/Entity-Framenwork">Entity Framenwork</a>
                            </li>
                            <li>
                                <a href="https://github.com/leandroVece/Api-C-">Api Rest</a>
                            </li>
                        </ul>
                        <div className="line-dec "> </div>
                    </div>

                    <div className="mt-4 fs-6 left-image-post border-bottom border-danger">
                        <div className="left-image-post mb-4">
                            <div className="row">
                                <div className="col-md-6">
                                    <div className="left-image ">
                                        <img className="w-75" src="./img/react.jpg" alt="" />
                                    </div>
                                </div>
                                <br />
                                <div className="col-md-6">
                                    <div className="right-text">
                                        <h4>React Js</h4>
                                        <span>
                                            Los temas que vamos a ver sobre React Js, son temas bastantes básicos sobre:
                                        </span>
                                        <ul>
                                            <li>Logica de paginacion</li>
                                            <li>Implementacion de perfil</li>
                                        </ul>
                                        <span>

                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div className="mt-4 fs-6">
                        <div className=" mb-4">
                            <div className="row">
                                <br />
                                <div className="col-md-6">
                                    <div className="left-text">
                                        <h4>Asp.Net 6</h4>
                                        <span>
                                            Este proyecto se hizo en VS Code. Si no estas familiarizado puede obtar por hacerlo en Visual Studio:
                                        </span>
                                        <ul>
                                            <li>Solicitudes limitadas con Entity Framenwork</li>
                                            <li>controladores Parametros nuleables</li>
                                            <li>Manejo de datos para la paginacion</li>
                                        </ul>
                                        <span>
                                            Entity Framework Core o EF Core, es una versión más sencilla y modular de .NET, tiene una mayor capacidad de rendimiento, consume menos recursos y es compatible con otras plataformas como Mac, Linux y Windows.
                                        </span>
                                    </div>
                                </div>
                                <div className="col-md-6">
                                    <div className="right-image ">
                                        <img className=" w-75" src="./img/net.png" alt="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </section >
        </>
    );
};

export default Parte3;