const initialState = {
    isLoggedIn: false,
    userName: ''
}
const AuthReducer = (state = initialState, action) => {
    switch(action.type){
        case "":
            return state;
        default: 
            return state;
    }
}
export default AuthReducer