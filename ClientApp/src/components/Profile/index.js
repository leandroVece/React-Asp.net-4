import { useNavigate } from "react-router-dom";
import Botones from "../BotonProfile/Index";
import EditImg from "../EditImg";
import React, { useState } from "react";
import { AuthRouter, useAuth } from "../Auth";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import './style.css';
import Loader from "../Loader";

const imgLocal = require.context("../../../public/upload", true);


const Profile = () => {
    const auth = useAuth();
    const navigate = useNavigate();
    const [img, setImg] = useState("https://img.icons8.com/bubbles/100/000000/user.png");


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

    const handelError = (e) => {
        e.target.src = "https://img.icons8.com/bubbles/100/000000/user.png";
        e.target.onerror = null;
    }

    const render = () => {
        if (auth.dbUser?.profile?.archivo?.img) {
            setImg("data:image/png;base64," + auth.dbUser?.profile?.archivo?.img)
        }
        else {
            setImg("https://img.icons8.com/bubbles/100/000000/user.png")
        }
    }


    return (
        <AuthRouter>
            <section className="cuerpo">
                <div className="col-sm-12 d-flex justify-content-center bg-dark">
                    <h1 className="text-center text-white">Perfil</h1>.
                </div>
                {auth.loading && <Loader />}
                {!auth.loading && (
                    <div>


                        <Botones
                            id={auth.dbUser.id}
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
                                                            <span className="">
                                                                <div className="circular--landscape">
                                                                    {/* <img src={img} onLoad={render} onError={handelError} className="img-radius "
                                                                        alt="User-Profile-Image" /> */}
                                                                    <img src={imgLocal(auth.dbUser.profile?.archivo ? `./${auth.dbUser.profile?.archivo?.name}` : "./user.png")} onLoad={render} onError={handelError} className="img-radius "
                                                                        alt="User-Profile-Image" />
                                                                </div>
                                                                <EditImg
                                                                    archivo={auth.dbUser?.profile?.archivo}
                                                                    origen={"perfil"}
                                                                    id={auth.dbUser?.profile?.id}
                                                                />
                                                            </span>
                                                        </div>
                                                        <h6 className="f-w-600">{auth.dbUser ? auth.dbUser?.profile?.nombre : 'Nombre'}</h6>
                                                        <p className="btn text-white"
                                                            onClick={() => handelEdit(auth.dbUser)}> Editar perfil <span>
                                                                <span className="bi bi-pencil"></span>
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
                                                                <h6 className="text-muted f-w-400">{auth.dbUser?.profile ? auth.dbUser?.profile?.nombre : 'Nombre'}</h6>
                                                            </div>
                                                            <div className="col-sm-6">
                                                                <p className="m-b-10 f-w-600">Phone</p>
                                                                <h6 className="text-muted f-w-400">{auth.dbUser?.profile ? auth.dbUser?.profile?.telefono : 'telefono'}</h6>
                                                            </div>
                                                        </div>
                                                        <h6 className="m-b-20 m-t-40 p-b-5 b-b-default f-w-600">Datos</h6>
                                                        <div className="row">
                                                            <div className="col-sm-6">
                                                                <p className="m-b-10 f-w-600">Direccion</p>
                                                                <h6 className="text-muted f-w-400">{auth.dbUser?.profile ? auth.dbUser?.profile?.direccion : 'Direccion'}</h6>
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
                    </div>
                )}
            </section >
        </AuthRouter>
    );
}

export default Profile;
