import React, { Component } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

function createData({ birthdaydate, id, username, usersurname }) {
  return { birthdaydate, id, username, usersurname };
}

const makeRows = (users) => [ ...users.map( item => createData( item) ) ];

export class AdminPage extends Component {

  state = {
    users: []
  };

  componentDidMount = () => {
    fetch('data/getusers')
    .then((response) => {
      return response.json();
    })
    .then((data) => {
      this.setState({
        users: data.items
      });
    })
  }

  render() {
    const classes = makeStyles({
      table: {
        minWidth: 650,
      },
    });

    console.log(this.state.users)
    return (
      <div>
        <TableContainer component={Paper}>
          <Table className={classes.table} size="small" aria-label="a dense table">
            <TableHead>
              <TableRow>
                <TableCell>Id</TableCell>
                <TableCell align="right">Дата Рождения</TableCell>
                <TableCell align="right">Имя</TableCell>
                <TableCell align="right">Фамилия</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {makeRows(this.state.users).map((row) => (
                <TableRow key={row.id}>
                  <TableCell component="th" scope="row">
                    {row.id}
                  </TableCell>
                  <TableCell align="right">{`${new Date(row.birthdaydate).getDate()}-${new Date(row.birthdaydate).getMonth()}-${new Date(row.birthdaydate).getFullYear()}`}</TableCell>
                  <TableCell align="right">{row.username}</TableCell>
                  <TableCell align="right">{row.usersurname}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </div>
    );
  }
}
