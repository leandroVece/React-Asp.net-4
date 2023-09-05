import React from "react";
import { useState, useEffect } from "react";
import { helpHttp } from "./Helper";

const GlobalContext = React.createContext();

const ContextProvider = (props) => {

    const [db, setDb] = useState([]);
    const [dataToEdit, setDataToEdit] = useState(null);
    const [url, setUrl] = useState(null);

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);

    const api = helpHttp();

    useEffect(() => {
        setLoading(true);
        helpHttp().get(url).then((res) => {
            if (!res.err) {
                setDb(res);
                setError(null);
            } else {
                setError(res);
                //console.log(res);
            }
            setLoading(false);
        });
    }, [url]);

    const createData = (data) => {
        delete data.id
        console.log(data)
        let options = {
            body: data,
            headers: { "content-type": "application/json" },
        };
        helpHttp().post(url, options).then((res) => {
            if (res.err) {
                setError(res);
                console.log(res)
            } else {
                //setDb([...db, res]);
                console.log("hecho")
            }
        })
    }
    const GetDataPost = (data) => {
        let options = {
            body: data,
            headers: { "content-type": "application/json" },
        };
        helpHttp().post(url, options).then((res) => {
            if (res.err) {
                setError(res);
                console.log(res)
            } else {
                setDb([...db, res]);
            }
        })
    }

    const updateData = (data) => {
        let id = data.id;
        var newData;
        let endpoint = `${url}/${id}`;
        let options = {
            body: data,
            headers: { "content-type": "application/json" },
        };
        api.put(endpoint, options).then((res) => {
            if (!res.err) {
                if (data.id_cadete) {
                    newData = db.map((el) => (el.id_cadete === data.id_cadete ? data : el));
                } if (data.id_cliente) {
                    newData = db.map((el) => (el.id_cliente === data.id_cliente ? data : el));
                } else {
                    newData = db.map((el) => (el.id_pedido === data.id_pedido ? data : el));
                }
                setDb(newData);
            } else {
                setError(res);
            }
        });
    }

    const deleteData = (id) => {
        let isDelete = window.confirm(
            `¿Estás seguro de eliminar el registro con el id '${id}'?`
        );
        if (isDelete) {
            let endpoint = `${url}/${id}`;
            let options = {
                headers: { "content-type": "application/json" },
            };
            api.del(endpoint, options).then((res) => {
                if (res.err) {
                    setError(res);
                } else {
                    let newData = db.filter((el) => el.id !== id);
                    setDb(newData);
                }
            });
        } else {
            return;
        }
    }

    const updateWihtUrl = (data, url) => {
        let endpoint = `${url}/${data.id}`;
        let options = {
            body: data,
            headers: { "content-type": "application/json" },
        };
        api.put(endpoint, options).then((res) => {
            if (res.err) setError(res);
            else return null;
        });
    }

    const deleteWihtUrl = (id, url) => {
        let endpoint = `${url}/${id}`;
        let options = {
            headers: { "content-type": "application/json" },
        };
        api.del(endpoint, options).then((res) => {
            if (res.err) {
                setError(res);
            } else {
                let newData = db.filter((el) => el.id !== id);
                setDb(newData);
            }
        });
    }

    const CreateWihtUrl = (data, url) => {
        delete data.id
        let options = {
            body: data,
            headers: { "content-type": "application/json" },
        };
        helpHttp().post(url, options).then((res) => {
            if (res.err) {
                setError(res);
            } else {
                setDb([...db, res]);
            }
        })
    }

    return (
        <GlobalContext.Provider value={{
            db,
            setDb,
            url,
            setUrl,
            dataToEdit,
            setDataToEdit,
            error,
            setError,
            loading,
            setLoading,
            createData,
            deleteData,
            updateData,
            updateWihtUrl,
            CreateWihtUrl,
            deleteWihtUrl,
            GetDataPost
        }} >
            {props.children}
        </GlobalContext.Provider>
    )
}

export { ContextProvider, GlobalContext }