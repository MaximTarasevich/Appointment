import React, { Component } from 'react';
import { 
  PieChart, 
  Pie, 
  Legend, 
  Cell, 
  AreaChart, 
  Area, 
  XAxis, 
  YAxis, 
  CartesianGrid, 
  Tooltip,
  BarChart,
  Bar,
} from 'recharts';

const COLORS = ['#0088FE', '#00C49F'];

const data = [
  {name: 'Page A', uv: 1500, },
  {name: 'Page B', uv: 3000, },
  {name: 'Page C', uv: 2500, },
  {name: 'Page D', uv: 2780, },
  {name: 'Page E', uv: 1890, },
  {name: 'Page F', uv: 2390, },
  {name: 'Page G', uv: 3490, },
];

export class Statistik extends Component {

  state = {
    allData: []
  };

  componentDidMount = () => {
    fetch('data/getdata')
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.setState({
          allData: data.items
        });
      })
      fetch('data/getusers')
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.setState({
          users: data.items.reduce( (accumulator, currentValue) => {
            if (accumulator.find( item => item.date === currentValue.userage )) {
              accumulator[accumulator.findIndex( item => item.date === currentValue.userage )].count++;
              return [
                ...accumulator
              ];
            } else {
              return [
                ...accumulator,
                {
                  count: 1,
                  date: currentValue.userage
                } 
              ]  
            }
          }, [])
        });
      })
  }

  makeCorrectDataForPieChart = () => { 
    return [
      {
        name: 'Male',
        value: this.state.allData.filter(item => item.gender === 0).length,
      }, 
      {
        name: 'Female',
        value: this.state.allData.filter(item => item.gender === 1).length,
      }
    ];
  }

  render() {
    console.log('this.state.users', this.state.users);
    return (
      <div style={{ height: '100%' }} >
        <div style={{display: 'flex', flexDirection: 'column', alignItems: 'center', marginTop: '20px'}}>
          <legend className="heading">
            Соотношение полов
          </legend>
          <PieChart width={730} height={250}>
            <Pie data={this.makeCorrectDataForPieChart()} dataKey="value" nameKey="name" cx="50%" cy="50%" outerRadius={100} fill="#8884d8" >
              {this.makeCorrectDataForPieChart().map((entry, index) => <Cell key={`afsdfasdfasdfasdfadf-${index}`} fill={COLORS[index % COLORS.length]} />)}
            </Pie>
            <Legend />
            <Tooltip />
          </PieChart>
        </div>
        {
          this.state.users ? 
            <div style={{display: 'flex', flexDirection: 'column', alignItems: 'center', marginTop: '80px'}}>
              <legend className="heading">
                Возрастные категории людей, воспользовавшиеся приложением
              </legend>

              <BarChart width={600} height={400} data={this.state.users.sort( (a,b) => a.date - b.date ) } margin={{top: 10, right: 30, left: 0, bottom: 0}}>
                <CartesianGrid strokeDasharray="3 3"/>
                <XAxis dataKey="date"/>
                <YAxis/>
                <Tooltip/>
                {/* <Area type='monotone' dataKey='count' stroke='#8884d8' fill='#8884d8' fillOpacity={0.3}/> */}
                <Bar type='monotone' dataKey='count' stroke='#8884d8' fill='#8884d8' fillOpacity={0.7} barSize={30} />
                {/* <Area type={cardinal} dataKey='uv' stroke='#82ca9d' fill='#82ca9d' fillOpacity={0.3}/> */}
              </BarChart>
            {/* <PieChart width={730} height={250}>
              <Pie data={this.makeCorrectDataForPieChart()} dataKey="value" nameKey="name" cx="50%" cy="50%" outerRadius={100} fill="#8884d8" >
                {this.makeCorrectDataForPieChart().map((entry, index) => <Cell key={`afsdfasdfasdfasdfadf-${index}`} fill={COLORS[index % COLORS.length]} />)}
              </Pie>
              <Legend />
              <Tooltip />
            </PieChart> */}
            </div> : 
            null
          }
      </div>
    );
  }
}
