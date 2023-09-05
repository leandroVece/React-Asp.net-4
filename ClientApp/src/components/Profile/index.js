import React, { useEffect } from "react";
import { AuthRouter, useAuth } from "../Auth";

import './style.css';
import { useNavigate } from "react-router-dom";
import Botones from "../BotonProfile/Index";
import EditImg from "../EditImg";



const Profile = () => {
    const auth = useAuth();
    const navigate = useNavigate();

    // useEffect(() => {
    //     if (auth.cookies.get('id_profile'))
    //     else
    //         auth.setDbUser(null)
    // })
    auth.setUrl(`/api/profile/${auth.cookies.get('id')}`)

    const handelEdit = (data) => {
        if (auth.dbUser) {
            delete data.userName
            delete data.userForeiKey
            navigate("/formProfile", { state: { data } })
        }
        navigate("/formProfile", { state: null })
    }
    console.log(auth.url);

    const { id, ...res } = auth.dbUser
    return (
        <section className="cuerpo">
            <AuthRouter>
                <div className="col-sm-12 d-flex justify-content-center bg-dark">
                    <h1 className="text-center text-white">Perfil</h1>.
                </div>

                <Botones
                    id={id}
                />

                <div className="page-content page-container" id="page-content">
                    <div className="padding">
                        <div className="row container d-flex justify-content-center">
                            <div className="col-xl-6 col-md-12">
                                <div className=" user-card-full carde">
                                    <div className="row m-l-0 m-r-0">
                                        <div className="col-sm-4 bg-c-lite-green user-profile">
                                            <div className="card-block text-center text-white">
                                                <div className="m-b-25">
                                                    <samp className="position-relative">
                                                        <img src="https://img.icons8.com/bubbles/100/000000/user.png" className="img-radius "
                                                            alt="User-Profile-Image" />
                                                        <span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-dark text-white">
                                                            <EditImg />
                                                        </span>
                                                    </samp>
                                                </div>
                                                <h6 className="f-w-600">{auth.dbUser ? auth.dbUser.nombre : 'Nombre'}</h6>
                                                <p className="btn text-white"
                                                    onClick={() => handelEdit(auth.dbUser)}> Editar <span>
                                                        <svg xmlns="http://www.w3.org/2000/svg" width="12" height="12" fill="currentColor" className="bi bi-pencil" viewBox="0 0 16 16">
                                                            <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z" />
                                                        </svg>
                                                    </span>

                                                </p>
                                                <i className=" mdi mdi-square-edit-outline feather icon-edit m-t-10 f-16"></i>
                                            </div>
                                        </div>
                                        <div className="col-sm-8">
                                            <div className="card-block">
                                                <h6 className="m-b-20 p-b-5 b-b-default f-w-600">Information</h6>
                                                <div className="row">
                                                    <div className="col-sm-6">
                                                        <p className="m-b-10 f-w-600">Nombre</p>
                                                        <h6 className="text-muted f-w-400">{auth.dbUser ? auth.dbUser.nombre : 'Nombre'}</h6>
                                                    </div>
                                                    <div className="col-sm-6">
                                                        <p className="m-b-10 f-w-600">Phone</p>
                                                        <h6 className="text-muted f-w-400">{auth.dbUser ? auth.dbUser.telefono : 'telefono'}</h6>
                                                    </div>
                                                </div>
                                                <h6 className="m-b-20 m-t-40 p-b-5 b-b-default f-w-600">Datos</h6>
                                                <div className="row">
                                                    <div className="col-sm-6">
                                                        <p className="m-b-10 f-w-600">Direccion</p>
                                                        <h6 className="text-muted f-w-400">{auth.dbUser ? auth.dbUser.direccion : 'Direccion'}</h6>
                                                    </div>
                                                    <div className="col-sm-6">
                                                        <p className="m-b-10 f-w-600">Nombre Usuario</p>
                                                        <h6 className="text-muted f-w-400">{auth.dbUser ? auth.dbUser.userName : 'Nombre Usuario'}</h6>
                                                    </div>
                                                </div>
                                                <ul className="social-link list-unstyled m-t-40 m-b-10">
                                                    <li><a href="#!" data-toggle="tooltip" data-placement="bottom" title=""
                                                        data-original-title="facebook" data-abc="true"><i
                                                            className="mdi mdi-facebook feather icon-facebook facebook"
                                                            aria-hidden="true"></i></a></li>
                                                    <li><a href="#!" data-toggle="tooltip" data-placement="bottom" title=""
                                                        data-original-title="twitter" data-abc="true"><i
                                                            className="mdi mdi-twitter feather icon-twitter twitter"
                                                            aria-hidden="true"></i></a></li>
                                                    <li><a href="#!" data-toggle="tooltip" data-placement="bottom" title=""
                                                        data-original-title="instagram" data-abc="true"><i
                                                            className="mdi mdi-instagram feather icon-instagram instagram"
                                                            aria-hidden="true"></i></a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </AuthRouter>
        </section>
    );
}

export default Profile;
