import React, { useState } from 'react'
import axios from 'axios'
import { useHistory } from 'react-router-dom';

export const RegisterUser = () => {
  const [Username, setUsername] = useState("")
  const [email, setemail] = useState("")
  const [ConformPassword, setComformPassword] = useState("")
  const [password, setPassword] = useState("")
  const [IsmatchedPassword, setIsMatchedPassword] = useState(true)
  const [BloadGru, setBloadGru] = useState("")
  const [response, setresponse] = useState("")


  const comparePasswords = (password, ConformPassword) => {
    setIsMatchedPassword(password === ConformPassword);
  };
  const redirect = useHistory()
  const bloodGroups = [
    'A+',
    'A-',
    'B+',
    'B-',
    'AB+',
    'AB-',
    'O+',
    'O-',
  ];

  const headers = {
    'Content-Type': 'application/json;charset=UTF-8',
    "Access-Control-Allow-Origin": "*",
  }


  const handleSubmit = () => {

    /*  e.preventDefualt();*/
    axios.post({

      url: 'https://localhost:5001/api/UserLoginDetails/InsertUserDetails',
      data: {
        ID: 1,
        Username: Username,
        password: "password",
        EmailId: email,
        BloadGru: BloadGru,
        CreateAT: new Date(),
        UpdateAT: new Date()
      },
      headers

    }).then(response => {
      setresponse(response.data);
    });
    redirect('/ReadUserDetails')
  }

  return (
    <>

      <div> <h3>User Registertion</h3> </div>

      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label className="form-label">User Name</label>
          <input type="Username" className="form-control"
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Email address</label>
          <input type="email" className="form-control" aria-describedby="emailHelp"
            onChange={(e) => setemail(e.target.value)}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Bload Group :</label>
          <select value={BloadGru} onChange={(e) => setBloadGru(e.target.value)}>
            <option value="">Select an option</option>
            {bloodGroups.map((option) => (
              <option key={option} value={option}>
                {option}
              </option>
            ))}
          </select>
        </div>


        <div className="mb-3">
          <label className="form-label">Password</label>
          <input type="password" className="form-control" aria-describedby="Password"
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>

        <div className="mb-3">
          <label className="form-label">Confirm password</label>
          <input type="Password" className="form-control" aria-describedby="Comform Password"
            onChange={(e) => setComformPassword(e.target.value)}
            onBlur={comparePasswords}
          />
        </div>
        {!IsmatchedPassword && <p >Passwords do not match.</p>}
        <button type="submit" className="btn btn-primary"
          onClick={handleSubmit}

        >Submit</button>
      </form>


    </>
  )
}
export default RegisterUser