import React, { Component } from 'react';
import Result from './Result';
import {formatInput} from '../utils/format-input';
import DateTimePicker from 'react-datetime-picker';
import { Input } from '@material-ui/core';

const PhysicalActivityRatio = {
  MIN: 1.2,
  LOW: 1.375,
  MEDIUM: 1.55,
  HIGH: 1.725,
  MAX: 1.9,
};

const CaloriesFormulaFactor = {
  AGE: 5,
  WEIGHT: 10,
  HEIGHT: 6.25,
};

const CaloriesFormulaConstant = {
  MALE: 5,
  FEMALE: -160
};

const CaloriesMinMaxRatio = {
  MIN: 0.85,
  MAX: 1.15
};

const getCorrectDateString = (date) => `${date.getDate()}.${date.getMonth()}.${date.getFullYear()}`;

const GenderType = {
	male: 0,
	female: 1
};

const PhysicalActivity = {
	min: 0,
	low: 1,
	medium: 2,
	high: 3,
};

export class Home extends Component {
	
	state = {
		selectedDate: new Date()
	};

  componentDidMount = () => {
    this.root = this.articleCounterRef;
    this.form = this.counterFormRef;
    this.elements = this.form.elements;
    this.parameters = this.elements.parameters.elements;
    this.submit = this.elements.submit;
    this.reset = this.elements.reset;
    this.gender = this.elements.gender;
    this.age = this.elements.age;
    this.weight = this.elements.weight;
    this.height = this.elements.height;
    this.activity = this.elements.activity;

    this.result = new Result(this.root);

    this.parametersItems = Array.from(this.parameters);
    
    this.form.addEventListener(`input`, this._onFormInput, true);
    this.form.addEventListener(`reset`, this._onFormReset);
    this.form.addEventListener(`submit`, this._onFormSubmit);


  }

  _onFormSubmit = (evt) => {
    evt.preventDefault();

	console.log(
		GenderType[this.elements.gender.value],
		this.elements.age.value,
		this.elements.weight.value,
		this.elements.height.value,
		PhysicalActivity[this.elements.activity.value],
		this.elements.firstname.value,
		this.elements.surname.value,
		getCorrectDateString(new Date(this.state.selectedDate))
	)


	fetch('data/Save', {
        method: 'POST',
        body: JSON.stringify({
			Gender: GenderType[this.elements.gender.value],
			Age: this.elements.age.value,
			Weight: this.elements.weight.value,
			Height: this.elements.height.value,
			Activity: PhysicalActivity[this.elements.activity.value],
			UserName: this.elements.firstname.value,
			UserSurname: this.elements.surname.value,
			BithdayDate: new Date(this.state.selectedDate)
        }),
        headers: {
          'Content-Type': 'application/json'
        }
	});

  const caloriesData = {
    norm: this.getCaloriesNorm(),
    min: this.getCaloriesMin(),
    max: this.getCaloriesMax()
  };

    this.result.show(caloriesData);
  }

  componentWillUnmount = () => {
    this.form.removeEventListener(`input`, this._onFormInput, true);
    this.form.removeEventListener(`reset`, this._onFormReset);
    this.form.removeEventListener(`submit`, this._onFormSubmit);
  }

  _onFormInput = () => {
    this.submit.disabled = !this.form.checkValidity();
    this.reset.disabled = !this.parametersItems.some((el) => el.value);

    this.age.value = formatInput(this.age);
    this.height.value = formatInput(this.height);
    this.weight.value = formatInput(this.weight);
  }

  _onFormReset = () => {
    this.reset.disabled = true;
    this.submit.disabled = true;
    this.result.hide();
  }

  getCaloriesNorm = () => {
    const age = CaloriesFormulaFactor.AGE * this.age.value;
    const weight = CaloriesFormulaFactor.WEIGHT * this.weight.value;
    const height = CaloriesFormulaFactor.HEIGHT * this.height.value;
    const gender = CaloriesFormulaConstant[this.gender.value.toUpperCase()];
    const activity = PhysicalActivityRatio[this.activity.value.toUpperCase()];

    return Math.round((weight + height - age + gender) * activity);
  }

  getCaloriesMin = () => {
    return Math.round(this.getCaloriesNorm() * CaloriesMinMaxRatio.MIN);
  }

  getCaloriesMax = () => {
    return Math.round(this.getCaloriesNorm() * CaloriesMinMaxRatio.MAX);
  }


  changeDate = date => this.setState({ selectedDate: date });

  render () {
    return (
      <main className="main">
      <div className="container">
        <article ref={ ref => this.articleCounterRef = ref} className="counter">
          <h1 className="counter__heading heading-main">
            Счётчик калорий
          </h1>
          <form ref={ ref => this.counterFormRef = ref} className="counter__form form" name="counter" action="#" method="post">
            <div className="form__item">
              <h2 className="heading">
                Пол
              </h2>
              <ul className="switcher">
                <li className="switcher__item">
                  <input id="gender-male" name="gender" value="male" type="radio" defaultChecked readOnly={true} required/>
                  <label htmlFor="gender-male">
                    Мужчина
                  </label>
                </li>
                <li className="switcher__item">
                  <input id="gender-female" name="gender" value="female" type="radio" required />
                  <label htmlFor="gender-female">
                    Женщина
                  </label>
                </li>
              </ul>
            </div>
            <fieldset className="form__item form__parameters" name="parameters">
              <legend className="heading">
              </legend>
              <div className="inputs-group">
                <div className="input">
                  <div className="input__heading">
                    <label className="heading" htmlFor="age">
                      Возраст
                    </label>
                    <span className="input__heading-unit">
                      лет
                    </span>
                  </div>
                  <div className="input__wrapper">
                    <input type="text" id="age" name="age" placeholder="0" inputMode="decimal" maxLength="3" required />
                  </div>
                </div>
                <div className="input">
                  <div className="input__heading">
                    <label className="heading" htmlFor="height">
                      Рост
                    </label>
                    <span className="input__heading-unit">
                      см
                    </span>
                  </div>
                  <div className="input__wrapper">
                    <input type="text" id="height" name="height" placeholder="0" inputMode="decimal" maxLength="3" required />
                  </div>
                </div>
                <div className="input">
                  <div className="input__heading">
                    <label className="heading" htmlFor="weight">
                      Вес
                    </label>
                    <span className="input__heading-unit">
                      кг
                    </span>
                  </div>
                  <div className="input__wrapper">
                    <input type="text" id="weight" name="weight" placeholder="0" inputMode="decimal" maxLength="3" required />
                  </div>
                </div>
              </div>
            </fieldset>
            <fieldset className="form__item form__names" name="names">
              <legend className="heading">
                Персональные данные
              </legend>
                <label className="heading" htmlFor="height">
                    Имя
                </label>
                <div style={{ marginTop: '-10px', width: '400px' }} className="input__wrapper">
                    <input type="text" id="firstname" name="firstname" placeholder="" inputMode="text" required />
                </div>

                <label className="heading" htmlFor="height">
                    Фамилия
                </label>
                <div style={{ marginTop: '-10px', width: '400px' }} className="input__wrapper">
                    <input type="text" id="surname" name="surname" placeholder="" inputMode="text" required />
                </div>

				<label className="heading" htmlFor="height">
                    Дата рождения
                </label>
                <div style={{ marginTop: '-10px', width: '400px' }} className="input__wrapper">
                    <DateTimePicker
                        value={this.state.selectedDate}
                        format={'yyyy-MM-dd'} 
						disableClock={true} 
						onChange={this.changeDate}
                    />
                </div>
                <div>
                    
                </div>
            </fieldset>

            <fieldset className="form__item">
              <legend className="heading">
                Физическая активность
              </legend>
              <ul className="radios-group">
                <li className="radio">
                  <div className="radio__wrapper">
                    <input id="activity-minimal" name="activity" value="min" type="radio" defaultChecked readOnly required />
                    <label htmlFor="activity-minimal">
                      Минимальная
                    </label>
                  </div>
                  <p className="radio__description">
                    Сидячая работа и нет физических нагрузок
                  </p>
                </li>
                <li className="radio">
                  <div className="radio__wrapper">
                    <input id="activity-low" name="activity" value="low" type="radio" required />
                    <label htmlFor="activity-low">
                      Низкая
                    </label>
                  </div>
                  <p className="radio__description">
                    Редкие, нерегулярные тренировки, активность в быту
                  </p>
                </li>
                <li className="radio">
                  <div className="radio__wrapper">
                    <input id="activity-medium" name="activity" value="medium" type="radio" required />
                    <label htmlFor="activity-medium">
                      Средняя
                    </label>
                  </div>
                  <p className="radio__description">
                    Тренировки 3-5 раз в неделю
                  </p>
                </li>
                <li className="radio">
                  <div className="radio__wrapper">
                    <input id="activity-high" name="activity" value="high" type="radio" required />
                    <label htmlFor="activity-high">
                      Высокая
                    </label>
                  </div>
                  <p className="radio__description">
                    Тренировки 6-7 раз в неделю
                  </p>
                </li>
                <li className="radio">
                  <div className="radio__wrapper">
                    <input id="activity-maximal" name="activity" value="max" type="radio" required />
                    <label htmlFor="activity-maximal">
                      Очень высокая
                    </label>
                  </div>
                  <p className="radio__description">
                    Больше 6 тренировок в неделю и физическая работа
                  </p>
                </li>
              </ul>
            </fieldset>
            <div className="form__submit">
              <button className="form__submit-button button" name="submit" type="submit" disabled>
                Рассчитать
              </button>
              <button className="form__reset-button" name="reset" type="reset" disabled>
                <svg width="24" height="24" viewBox="0 0 24 24" fill="#FD3636" xmlns="http://www.w3.org/2000/svg">
                  <path fillRule="evenodd" clipRule="evenodd" d="M13.4143 12.0002L18.7072 6.70725C19.0982 6.31625 19.0982 5.68425 18.7072 5.29325C18.3162 4.90225 17.6842 4.90225 17.2933 5.29325L12.0002 10.5862L6.70725 5.29325C6.31625 4.90225 5.68425 4.90225 5.29325 5.29325C4.90225 5.68425 4.90225 6.31625 5.29325 6.70725L10.5862 12.0002L5.29325 17.2933C4.90225 17.6842 4.90225 18.3162 5.29325 18.7072C5.48825 18.9022 5.74425 19.0002 6.00025 19.0002C6.25625 19.0002 6.51225 18.9022 6.70725 18.7072L12.0002 13.4143L17.2933 18.7072C17.4882 18.9022 17.7443 19.0002 18.0002 19.0002C18.2562 19.0002 18.5122 18.9022 18.7072 18.7072C19.0982 18.3162 19.0982 17.6842 18.7072 17.2933L13.4143 12.0002Z"/>
                </svg>
                <span>
                  Очистить поля и расчёт
                </span>
              </button>
            </div>
          </form>
          <section className="counter__result counter__result--hidden">
            <h2 className="heading">
              Ваша норма калорий
            </h2>
            <ul className="counter__result-list">
              <li className="counter__result-item">
                <h3>
                  <span id="calories-norm">3 800</span> ккал
                </h3>
                <p>
                  поддержание веса
                </p>
              </li>
              <li className="counter__result-item">
                <h3>
                  <span id="calories-minimal">3 300</span> ккал
                </h3>
                <p>
                  снижение веса
                </p>
              </li>
              <li className="counter__result-item">
                <h3>
                  <span id="calories-maximal">4 000</span> ккал
                </h3>
                <p>
                  набор веса
                </p>
              </li>
            </ul>
          </section>
        </article>
      </div>
    </main>
    );
  }
}
