import Login from "./components/Login";
import Register from "./components/Register";
import Home from './components/Home';
import Cadete from './components/Cadete';
import Pedido from './components/Pedido';
import Cliente from './components/Cliente';
import Error from "./components/Error";
import Usuarios from "./components/User";
import TomarPedido from "./components/TomarPedido";
import ActionPedido from "./components/ActionPedido";
import FormPedido from "./components/FormPedido";
import UpdateUser from "./components/UpdateUser";
import Profile from "./components/Profile";
import FormProfile from "./components/FormProfile";
import Articulo from "./components/Articulos";
import FormArticulo from "./components/FormArticulo";
import Details from "./components/DellateArticulo";

const AppRoutes = [
  {
    index: true,
    name: "Home",
    path: '/',
    private: false,
    element: <Home />
  },
  {
    index: true,
    name: "Articulos",
    path: '/articulo',
    private: false,
    element: <Articulo />
  },
  {
    index: true,
    name: "Nuevo Articulos",
    path: '/formArticulo',
    private: false,
    element: <FormArticulo />
  },
  {
    name: "Cadete",
    path: '/cadete',
    private: true,
    exclusive: true,
    element: <Cadete />
  },
  {
    name: "Cliente",
    path: '/cliente',
    private: true,
    element: <Cliente />
  },
  {
    name: "Pedido",
    path: '/pedido',
    element: <Pedido />
  },
  {
    name: "Login",
    path: '/login',
    private: false,
    publicOnly: true,
    element: <Login />
  },
  {
    name: "Register",
    path: '/register',
    publicOnly: true,
    element: <Register />
  },
  {
    invisible: true,
    path: '/formPedido',
    element: <FormPedido />
  },
  {
    invisible: true,
    path: '/ArticuloDetail',
    element: <Details />
  },
  {
    invisible: true,
    path: '/ArticuloDetail/:id',
    element: <Details />
  },
  {
    invisible: true,
    path: '/formProfile',
    element: <FormProfile />
  },
  {
    invisible: true,
    path: '/tomarPedido',
    element: <TomarPedido />
  },
  {
    invisible: true,
    path: '/actionPedido',
    element: <ActionPedido />
  },
  {
    name: "Usuarios",
    path: '/usuarios',
    private: true,
    exclusive: true,
    element: <Usuarios />
  },
  {
    path: '/usuarios/:usuarioPage',
    private: true,
    exclusive: true,
    invisible: true,
    element: <Usuarios />
  },
  {
    path: '/cadete/:cadetepage',
    private: true,
    exclusive: true,
    invisible: true,
    element: <Cadete />
  },
  {
    path: '/cliente/:clientePage',
    private: true,
    exclusive: true,
    invisible: true,
    element: <Cliente />
  },
  {
    path: '/pedido/:pedidoPage',
    private: true,
    exclusive: true,
    invisible: true,
    element: <Pedido />
  },
  {
    name: "Perfil",
    path: '/profile',
    private: true,
    element: <Profile />
  },
  {
    path: '/UpdateUser',
    private: true,
    exclusive: true,
    invisible: true,
    element: <UpdateUser />
  },
  {
    path: '*',
    private: false,
    element: <Error />,
  }
];

export { AppRoutes };
