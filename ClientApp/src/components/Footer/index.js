import React from "react";
import './style.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';

const Footer = function () {

    <footer class="footer mt-auto py-3 bg-light"></footer>

    return (
        <>

            <div className="bodyConteiner">
                <footer className=" bg-dark  text-center text-white sticky-bottom ">

                    <div className="container-fluid p-4 pb-0">

                        <section className="mb-4">

                            <a className="btn btn-outline-light btn-floating rounded-circle m-1"
                                href="https://www.facebook.com/leandroandres.vece" role="button">
                                <i className="bi bi-facebook ">
                                </i>
                            </a>

                            <a className="btn btn-outline-light btn-floating rounded-circle m-1"
                                href="https://leandrovece.github.io/leandroVece/" role="button"
                            ><i className="bi bi-google">
                                </i></a>

                            <a className="btn btn-outline-light btn-floating rounded-circle m-1"
                                href="https://www.instagram.com/leosvece/" role="button"
                            ><i className="bi bi-instagram"></i></a>

                            <a className="btn btn-outline-light btn-floating rounded-circle m-1"
                                href="https://www.linkedin.com/in/leandro-andres-suarez-vece-90148087/" role="button"
                            ><i className="bi bi-linkedin">
                                </i></a>

                            <a className="btn btn-outline-light btn-floating rounded-circle m-1"
                                href="https://github.com/leandroVece" role="button"
                            ><i className="bi bi-github">
                                </i></a>

                            <p className="text-white"></p>
                            <span className="mb-3"> Este proyecto se inicio para ayudar a aquellos que quieran aprender sobre el mundo IT
                                tengan un lugar mas que les pueda servir como guia de forma simple y gratuita.</span>
                        </section>

                    </div>
                    <div className="text-center p-3 rgbFooter">
                        <span> Gracias por entrar a este lugar. Mi correo: </span>
                        <a className="text-white" href="maito:leovece1@gmail.com">leovece1@gmail.com</a>
                    </div>

                </footer ></div>
        </>
    );
};

export default Footer;