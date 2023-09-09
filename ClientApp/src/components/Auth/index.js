import React, { useEffect, useState } from "react"
import Cookies from 'universal-cookie';
import { helpHttp } from "../../Helper";
import { Navigate } from "react-router-dom";

const authContext = React.createContext();

function AuthProvider({ children }) {
    const cookies = new Cookies();
    const [url, setUrl] = useState("")
    const api = helpHttp();
    const [loginTouch, setLoginTouch] = useState(false);
    const [dbUser, setDbUser] = useState([]);
    const [totalPages, setTotalPage] = useState()
    const [loading, setLoading] = useState(false);


    useEffect(() => {
    }, [loginTouch])

    useEffect(() => {
        setLoading(true);
        let options = {
            headers: {
                "Authorization": "Bearer " + cookies.get("Token")
            }
        };
        helpHttp().get(url, options).then((res) => {
            if (!res.err) {
                setDbUser(res)
                setTotalPage(res.totalPages)
                setLoading(false);

            } else {
                setDbUser(null)
                //console.log(res)
            }
        });
    }, [url]);

    const createWithToken = (data) => {
        delete data.id
        let options = {
            body: data,
            headers: {
                'Content-Type': 'application/json',
                "Authorization": "Bearer " + cookies.get("Token")
            },
        };
        helpHttp().post(url, options).then((res) => {
            if (res.err) {
                //setError(res);
                alert("A oc¿urrido un error inesperado. Vuelva atras e intente de nuevo")
            } else {
                //console.log(res);
                setDbUser([...dbUser, res]);
            }
        })
    }

    const UpdateWithToken = (data) => {
        let endpoint = `${url}/${data.id}`;
        let options = {
            body: data,
            headers: {
                'Content-Type': 'application/json',
                "Authorization": "Bearer " + cookies.get("Token")
            },
        };
        api.put(endpoint, options).then((res) => {
            if (!res.err) {

            } else {
                //setError(res);
            }
        });
    }

    const deleteWithToken = (id) => {
        let isDelete = window.confirm(
            `¿Estás seguro de eliminar el registro con el id '${id}'?`
        );
        if (isDelete) {
            let endpoint = `/user/${id}`;
            let options = {
                headers: {
                    'Content-Type': 'application/json',
                    "Authorization": "Bearer " + cookies.get("Token")
                },
            };
            api.del(endpoint, options).then((res) => {
                if (!res.err) {
                } else {
                    //setError(res);
                }
            });
        } else {
            return;
        }
    }
    const deleteWithTokenAndUrl = (id, url) => {
        let endpoint = `/${url}/${id}`;
        //console.log(endpoint)
        let options = {
            headers: {
                'Content-Type': 'application/json',
                "Authorization": "Bearer " + cookies.get("Token")
            },
        };
        api.del(endpoint, options).then((res) => {
            if (!res.err) {
            } else {
                //setError(res);
            }
        });
    }

    const login = (data) => {

        cookies.set('id', data.id, { path: '/', maxAge: 60 * 60 * 24 })
        cookies.set('name', data.userName, { path: '/', maxAge: 30 * 60 * 24 })
        cookies.set('rol', data.rol, { path: '/', maxAge: 60 * 60 * 24 })
        cookies.set('id_profile', data.id_profile, { path: '/', maxAge: 60 * 60 * 24 })
        cookies.set('Token', data.token, { path: '/', maxAge: 60 * 60 * 24 })

    }

    const logout = () => {
        cookies.remove('id', { path: '/' })
        cookies.remove('name', { path: '/' })
        cookies.remove('rol', { path: '/' })
        cookies.remove('id_profile', { path: '/' })
        cookies.remove('Token', { path: '/' })
        return <Navigate to='/login' />
    }

    const auth = {
        cookies, login, logout, UpdateWithToken, deleteWithToken, loginTouch, setLoginTouch,
        setDbUser, dbUser, setUrl, url, createWithToken, totalPages, loading, deleteWithTokenAndUrl
    }

    return (
        <authContext.Provider value={auth}>
            {children}
        </authContext.Provider>
    )
}

//llamaremos al useContext
function useAuth() {
    const auth = React.useContext(authContext)
    return auth
}

function AuthRouter(props) {
    const auth = useAuth()
    if (!auth.cookies.get("name")) {
        return <Navigate to='/error' />
    }
    return props.children
}

//de manera provisional exportaremos el provider para acceder a la informacion
export {
    AuthProvider,
    useAuth,
    AuthRouter
}